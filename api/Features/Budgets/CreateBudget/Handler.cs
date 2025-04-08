using Marten;
using Wolverine;

namespace Accounting.Api.Features.Budgets.CreateBudget
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
            _session.Insert(command.budget);
            await _session.SaveChangesAsync(command.ct);
            return new Response
            {
                Saved = true
            };
        }
    }
}