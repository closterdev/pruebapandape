using Pandape.Data.Entities;

namespace Pandape.Data.Repository
{
    public interface ICandidateRepository
    {
        Task AddCandidate(Candidate newCandidate);

        Task<Candidate?> GetCandidateById(int candidateId);

        Task<List<Candidate>> GetAllCandidates();

        Task<int> UpdateCandidate(Candidate candidate);

        Task<int> DeleteCandidate(Candidate candidate);

        void Dispose();
    }
}
