using Accounting.Api.Entities;
using Marten;
using Wolverine;

namespace Accounting.Api.Features.Budgets.GetBudgets
{
    public class Handler : IWolverineHandler
    {
        IDocumentSession _session;
        public Handler(IDocumentSession session)
        {
            _session = session;
        }

        public async Task<Response> Handle(Command command)
        {
            var budgets = await _session.Query<Budget>().Where(x => x.UserId == command.userId).ToListAsync();
            return new Response
            {
                Budgets = budgets
            };
        }
    }
}