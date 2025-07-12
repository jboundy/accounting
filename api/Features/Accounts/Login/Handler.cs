using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Accounting.Api.Configuration;
using Accounting.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Wolverine;

namespace Accounting.Api.Features.Accounts.Login
{
    public class Handler : IWolverineHandler
    {
        private readonly UserManager<Account> _userManager;
        public readonly JwtSettings _jwtSettings;
        public Handler(UserManager<Account> userManager, JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _userManager = userManager;
        }

        public async Task<Response> Handle(Command command)
        {
            var user = await _userManager.FindByEmailAsync(command.userName);
            var passwordResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, command.password);
            if (passwordResult == PasswordVerificationResult.Success || passwordResult == PasswordVerificationResult.SuccessRehashNeeded)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
                var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _jwtSettings.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow)
                                .ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                        new Claim("userId", user.Id.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.EmailAddress)
                    };
                claims.AddRange(user.Roles.Select(r => new Claim(ClaimTypes.Role, r.Name)));

                var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(_jwtSettings.ExpireDays),
                    signingCredentials: creds);

                var jwtCode = new JwtSecurityTokenHandler().WriteToken(token);

                return new Response
                {
                    UserId = user.Id.ToString(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.EmailAddress,
                    Authorized = true,
                    JWTCode = jwtCode,
                    Roles = user.Roles.Select(x => x.Name).ToArray()
                };
            }

            return new Response
            {
                Authorized = false
            };
        }
    }
}