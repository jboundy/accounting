using Api.Configuration;
using FastEndpoints;
using FastEndpoints.Swagger;
using JasperFx.Core;
using Marten;
using Weasel.Core;
using Wolverine;
using Wolverine.ErrorHandling;
using Wolverine.Marten;


namespace Accounting.Api
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMarten(opts =>
            {
                opts.Connection(builder.Configuration.GetConnectionString("DefaultConnection"));
                opts.DatabaseSchemaName = "db";
                opts.UseSystemTextJsonForSerialization();
                opts.CreateDatabasesForTenants(c =>
                {
                    c.MaintenanceDatabase(builder.Configuration.GetConnectionString("DefaultConnection"));
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
            .IntegrateWithWolverine()
            .UseLightweightSessions()
            .UseNpgsqlDataSource();

            builder.Services.AddNpgsqlDataSource(builder.Configuration.GetConnectionString("DefaultConnection"));
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

            var app = builder.Build();

            app.UseHttpsRedirection(); ;
            app.UseFastEndpoints().UseSwaggerGen();
            app.Run();
        }
    }
}
