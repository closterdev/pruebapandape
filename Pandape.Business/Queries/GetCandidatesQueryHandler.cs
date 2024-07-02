using Pandape.Business.Interfaces;
using Pandape.Data.Dto;
using Pandape.Data.Entities;
using Pandape.Data.Query;
using Pandape.Data.Repository;

namespace Pandape.Business.Queries
{
    public class GetCandidatesQueryHandler : IQueryHandler<GetCandidatesQuery, List<CandidateDto>>
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetCandidatesQueryHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<List<CandidateDto>> Handle(GetCandidatesQuery query)
        {
            List<Candidate> candidates = await _candidateRepository.GetAllCandidates();
            List<CandidateDto> list = new();

            if (candidates.Any())
            {
                candidates.ForEach(c => list.Add(c.ToDto()));
            }

            return list;
        }
    }
}
