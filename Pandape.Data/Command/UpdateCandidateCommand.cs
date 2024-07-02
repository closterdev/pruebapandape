using Pandape.Data.Dto;

namespace Pandape.Data.Command
{
    public class UpdateCandidateCommand
    {
        public int IdCandidate { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public List<CandidateExperienceDto> Experiences { get; set; }
    }
}
