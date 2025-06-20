using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Features.Accounts.ResetPassword
{
    public record Command(Request req, CancellationToken ct);
}