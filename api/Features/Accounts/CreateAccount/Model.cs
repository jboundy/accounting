using Accounting.Api.Entities;
using Accounting.Api.Features.Accounts.AccountStore;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Accounting.Api.Features.Accounts.CreateAccount
{
    public class Request
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }

    public class Response
    {
        public bool Saved { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}