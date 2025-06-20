using Marten.AspNetCore.Identity.Models;

namespace Accounting.Api.Entities
{
    public class Account : MartenIdentityUser
    {
        public Account()
        {

        }
        public Account(string email, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = email;
            NormalizedUserName = email.ToUpper();
            EmailAddress = email;
            NormalizedEmailAddress = email.ToUpper();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

