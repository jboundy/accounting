using FastEndpoints;
using FluentValidation;

namespace Accounting.Api.Features.Accounts.Login
{
    public class Request
    {
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