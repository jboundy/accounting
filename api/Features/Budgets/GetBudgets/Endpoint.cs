using FastEndpoints;
using Wolverine;

namespace Accounting.Api.Features.Budgets.GetBudgets
{
    public class Endpoint : Endpoint<Request, Response>
    {
        IMessageBus _messageBus;

        public Endpoint(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public override void Configure()
        {
            Get("budgets/{userId}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var response = await _messageBus.InvokeAsync<Response>(new Command(req.UserId, ct));
            await SendAsync(response, StatusCodes.Status200OK, ct);
        }
    }
}