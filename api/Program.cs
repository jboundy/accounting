using System.Text;
using Accounting.Api.Configuration;
using Accounting.Api.Entities;
using Accounting.Api.Features.Accounts.AccountStore;
using Accounting.Api.Services;
using Accounting.Api.Services.Interfaces;
using FastEndpoints;
using FastEndpoints.Swagger;
using Marten;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Weasel.Core;
using Wolverine;
using Wolverine.Marten;

namespace Accounting.Api
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var hostSettings = builder.Configuration.GetSection("Host").Get<HostSettings>()!;
            builder.Services.AddSingleton(hostSettings);

            var mailSettings = builder.Configuration.GetSection("Mail").Get<MailSettings>()!;
            builder.Services.AddSingleton(mailSettings);

            var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>()!;
            builder.Services.AddSingleton(jwtSettings);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddMarten(opts =>
            {
                opts.Connection(connectionString);
                opts.DatabaseSchemaName = "db";
                opts.UseSystemTextJsonForSerialization();
                opts.CreateDatabasesForTenants(c =>
                {
                    c.MaintenanceDatabase(connectionString);
                    c.ForTenant()
                        .CheckAgainstPgDatabase()
                        .WithOwner("postgres")
                        .WithEncoding("UTF-8")
                        .ConnectionLimit(-1);
                });

                // If we're running in development mode, let Marten just take care
                // of all necessary schema building and patching behind the scenes
                if (builder.Environment.IsDevelopment())
                {
                    opts.AutoCreateSchemaObjects = AutoCreate.All;
                }
            })
            .IntegrateWithWolverine();

            builder.Services
                .AddIdentityCore<Account>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredUniqueChars = 1;
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<Role>()
                .AddUserStore<UserStore>()
                .AddRoleStore<RoleStore>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IMailService, MailService>();

            builder.Host.UseWolverine().StartAsync();
            // builder.Host.UseWolverine(opts =>
            // {
            //     opts.Policies.OnAnyException().RetryWithCooldown(50.Milliseconds(), 100.Milliseconds(), 250.Milliseconds());

            //     opts.Policies.DisableConventionalLocalRouting();
            //     opts.UseRabbitMq().AutoProvision();

            //     opts.Policies.UseDurableInboxOnAllListeners();
            //     opts.Policies.UseDurableOutboxOnAllSendingEndpoints();

            //     opts.ListenToRabbitQueue("chaos2");
            //     opts.PublishAllMessages().ToRabbitQueue("chaos2");

            //     opts.Policies.AutoApplyTransactions();
            // });

            builder.Services.AddFastEndpoints().SwaggerDocument(o =>

                o.DocumentSettings = s =>
                {
                    s.Title = "My API";
                    s.Version = "v1";
                    s.DocumentProcessors.Add(new CustomSchemaDocumentProcessor());
                }
            );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = null;
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.Audience = "your-api-audience";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Key)) // keep in config!
                    };

                    // ✅ Prevent redirects for APIs
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("AUTH FAIL:");
                            Console.WriteLine(context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            return context.Response.WriteAsync("{\"error\": \"Unauthorized\"}");
                        }
                    };

                });
            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseFastEndpoints().UseSwaggerGen();
            app.Run();
        }
    }
}
