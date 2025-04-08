using Accounting.Api.Entities;
using Marten;
using Wolverine;

namespace Accounting.Api.Features.Budgets.GetBudget
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
            var budget = await _session.LoadAsync<Budget>(command.id, command.ct);
            return new Response
            {
                Budget = budget
            };
        }
    }
}