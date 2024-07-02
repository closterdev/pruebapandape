using Pandape.Business.Interfaces;
using Pandape.Data.Command;
using Pandape.Data.Repository;

namespace Pandape.Business.Commands
{
    public class DeleteCandidateCommandHandler : ICommandHandler<DeleteCandidateCommand, int>
    {
        private readonly ICandidateRepository _candidateContext;

        public DeleteCandidateCommandHandler(ICandidateRepository dataContext)
        {
            _candidateContext = dataContext;
        }

        public async Task<int> Handle(DeleteCandidateCommand command)
        {
            var candidate = _candidateContext.GetCandidateById(command.IdCandidate);
            if (candidate == null)
            {
                return 0;
            }

            return await _candidateContext.DeleteCandidate(candidate.Result);
        }
    }
}
