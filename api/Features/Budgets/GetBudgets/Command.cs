using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Features.Budgets.GetBudgets
{
    public record Command(Guid userId, CancellationToken ct);
}