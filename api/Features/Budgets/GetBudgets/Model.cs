using Accounting.Api.Entities;
using FastEndpoints;
using FluentValidation;

namespace Accounting.Api.Features.Budgets.GetBudgets
{
    public class Request
    {
        public int UserId { get; set; }
    }

    public class Response
    {
        public IReadOnlyList<Budget> Budgets { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("Must have user id.");
        }
    }
}