using System.Text.Json.Serialization;
using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Budgets.CreateBudget
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

        }
    }
}