using Marten.AspNetCore.Identity.Models;

namespace Accounting.Api.Entities
{
    public class Role : MartenIdentityRole
    {
        public Role() : base("placeholder")
        {
        }

        public Role(string name) : base(name)
        {
        }
    }
}