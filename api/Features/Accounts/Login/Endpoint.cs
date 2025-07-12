using FastEndpoints;
using Wolverine;

namespace Accounting.Api.Features.Accounts.Login
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
            Post("login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var response = await _messageBus.InvokeAsync<Response>(new Command(req.UserName, req.Password, ct));
            if (response.Authorized)
            {
                await SendAsync(response, StatusCodes.Status200OK, ct);
            }
            else
            {
                await SendUnauthorizedAsync(ct);
            }
        }
    }
}