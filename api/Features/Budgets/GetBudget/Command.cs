using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.GetBudget
{
    public record Command(int id, CancellationToken ct);
}