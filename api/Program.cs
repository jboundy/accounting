using Accounting.Api.Context;
using Api.Configuration;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AccountingContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddFastEndpoints().SwaggerDocument(o =>
                o.DocumentSettings = s =>
                {
                    s.Title = "My API";
                    s.Version = "v1";
                    s.DocumentProcessors.Add(new CustomSchemaDocumentProcessor());
                });

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseFastEndpoints().UseSwaggerGen();
            app.Run();
        }
    }
}
