using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;
using Marten;
using Microsoft.AspNetCore.Identity;

namespace Accounting.Api.Extensions
{
    public static class SeedRolesExtension
    {
        public static async Task SeedRolesAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var roleStore = scope.ServiceProvider.GetRequiredService<IRoleStore<Role>>();
            var session = scope.ServiceProvider.GetRequiredService<IDocumentSession>();
            var cancellationToken = CancellationToken.None;

            var requiredRoles = new[] { "Admin" };

            foreach (var roleName in requiredRoles)
            {
                var existing = await roleStore.FindByNameAsync(roleName, cancellationToken);
                if (existing == null)
                {
                    await roleStore.CreateAsync(new Role(roleName), cancellationToken);
                }
            }

            await session.SaveChangesAsync(cancellationToken);
        }
    }
}