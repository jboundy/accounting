using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;
using Wolverine;

namespace Accounting.Api.Features.Accounts.ChangePassword
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
            Post("account/changepassword");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var response = await _messageBus.InvokeAsync<Response>(new Command(req.UserId, req.CurrentPassword, req.NewPassword, ct));
            await SendAsync(response, StatusCodes.Status200OK, ct);
        }
    }
}