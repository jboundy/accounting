using Accounting.Api.Entities;
using FastEndpoints;
using Marten;
using Wolverine;

namespace Accounting.Api.Features.Budgets.CreateBudget
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        private IMessageBus _messageBus;

        public Endpoint(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }
        public override void Configure()
        {
            Post("budget");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var response = await _messageBus.InvokeAsync<Response>(new Command(req.Budget, ct));
            await SendAsync(response, StatusCodes.Status200OK, ct);
        }
    }
}