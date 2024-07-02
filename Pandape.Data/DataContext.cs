using Pandape.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Pandape.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}