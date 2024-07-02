using Pandape.Data.Entities;

namespace Pandape.Data.Dto
{
    public static class CandidateExtensions
    {
        public static CandidateDto? ToDto(this Candidate candidate)
        {
            if (candidate == null)
            {
                return null;
            }

            return new CandidateDto
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                Birthday = candidate.Birthday,
                Email = candidate.Email,
                InsertDate = candidate.InsertDate,
                ModifyDate = candidate.ModifyDate
            };
        }
    }
}
