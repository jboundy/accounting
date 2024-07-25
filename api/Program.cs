
using Accounting.Api.Context;
using FastEndpoints;

using Microsoft.EntityFrameworkCore;

namespace Accounting.Api
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddFastEndpoints();

            builder.Services.AddDbContext<AccountingContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.Run();
        }
    }
}
