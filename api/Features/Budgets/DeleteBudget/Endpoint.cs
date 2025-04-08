using FastEndpoints;
using Wolverine;

namespace Accounting.Api.Features.Budgets.DeleteBudget
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        IMessageBus _messageBus;

        public Endpoint(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }
        public override void Configure()
        {
            Delete("budget");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var response = await _messageBus.InvokeAsync<Response>(new Command(req.Budget, ct));
            await SendAsync(response, StatusCodes.Status200OK, ct);
        }
    }
}