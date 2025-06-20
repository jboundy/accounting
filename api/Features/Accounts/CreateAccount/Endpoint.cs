using FastEndpoints;
using Wolverine;

namespace Accounting.Api.Features.Accounts.CreateAccount
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
            AllowAnonymous();
            Post("account");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var response = await _messageBus.InvokeAsync<Response>(new Command(req.FirstName, req.LastName, req.UserName, req.Password, ct));
            await SendAsync(response, StatusCodes.Status200OK, ct);
        }
    }
}