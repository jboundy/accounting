using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Accounts.DeleteAccount
{
    public record Command(string userName, CancellationToken ct);
}