using Microsoft.EntityFrameworkCore;
using Pandape.Data.Entities;

namespace Pandape.Data.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DataContext _context;

        public CandidateRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddCandidate(Candidate newCandidate)
        {
            _context.Candidates.Add(newCandidate);
            await _context.SaveChangesAsync();
        }

        public async Task<Candidate?> GetCandidateById(int candidateId)
        {
            return await _context.Candidates.FindAsync(candidateId);
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<int> UpdateCandidate(Candidate candidate)
        {
            _context.Update(candidate);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCandidate(Candidate candidate)
        {
            _context.Remove(candidate);
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
