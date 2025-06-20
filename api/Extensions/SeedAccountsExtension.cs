using Accounting.Api.Entities;
using Marten;
using Microsoft.AspNetCore.Identity;

namespace Accounting.Api.Extensions
{
    public static class SeedAccountsExtension
    {
        public static async Task SeedAccountsAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Account>>();
            var roleStore = scope.ServiceProvider.GetRequiredService<IRoleStore<Role>>();
            var session = scope.ServiceProvider.GetRequiredService<IDocumentSession>();
            var cancellationToken = CancellationToken.None;

            var requiredUser = new[] { "Admin" };
            var requiredPassword = "P@ssword123";
            var requiredRoles = new[] { "Admin" };

            foreach (var userName in requiredUser)
            {
                var user = await userManager.FindByEmailAsync(userName);

                if (user == null)
                {
                    var email = $"{userName.ToLowerInvariant()}@example.com";
                    var password = "Password1!";
                    var newUser = new Account(email, "Test", "Admin")
                    {
                        IsEmailConfirmed = true
                    };

                    var hashedPassword = userManager.PasswordHasher.HashPassword(newUser, password);
                    newUser.PasswordHash = hashedPassword;

                    var result = await userManager.CreateAsync(newUser, requiredPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRolesAsync(newUser, requiredRoles);
                    }
                    else
                    {
                        throw new Exception("The admin user cannot be created");
                    }

                }
            }

            await session.SaveChangesAsync(cancellationToken);
        }
    }
}