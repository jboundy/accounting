using Accounting.Api.Entities;
using FastEndpoints;
using FluentValidation;

namespace Accounting.Api.Features.Budgets.DeleteBudget
{
    public class Request
    {
        public required Budget Budget { get; set; }
    }

    public class Response
    {
        public bool Saved { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Budget).NotNull().WithMessage("Budget is required.");
        }
    }
}