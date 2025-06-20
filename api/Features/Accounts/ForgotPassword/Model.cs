using FastEndpoints;
using FluentValidation;

namespace Accounting.Api.Features.Accounts.ForgotPassword
{
    public class Request
    {
        public required string Email { get; set; }
    }

    public class Response
    {
        public bool Saved { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.");

        }
    }
}