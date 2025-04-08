using Marten;
using Wolverine;

namespace Accounting.Api.Features.Budgets.DeleteBudget
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
            _session.Delete(command.budget);
            await _session.SaveChangesAsync(command.ct);
            return new Response
            {
                Saved = true
            };
        }
    }
}