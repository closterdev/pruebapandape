using Pandape.Business.Interfaces;
using Pandape.Data.Dto;
using Pandape.Data.Entities;
using Pandape.Data.Query;
using Pandape.Data.Repository;

namespace Pandape.Business.Queries
{
    public class GetCandidateQueryHandler : IQueryHandler<GetCandidateQuery, CandidateDto>
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetCandidateQueryHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<CandidateDto> Handle(GetCandidateQuery query)
        {
            Candidate candidate = await _candidateRepository.GetCandidateById(query.IdCandidate);
            return candidate.ToDto();
        }
    }
}
