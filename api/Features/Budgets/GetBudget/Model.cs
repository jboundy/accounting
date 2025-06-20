using Accounting.Api.Entities;
using FastEndpoints;
using FluentValidation;

namespace Accounting.Api.Features.Budgets.GetBudget
{
    public class Request
    {
        public int Id { get; set; }
    }

    public class Response
    {
        public required Budget Budget { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Budget Id is required.");
        }
    }
}