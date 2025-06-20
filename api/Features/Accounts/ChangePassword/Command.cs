using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Accounts.ChangePassword
{
    public record Command(string userId, string currentPassword, string newPassword, CancellationToken ct);
}