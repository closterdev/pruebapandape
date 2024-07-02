namespace Pandape.Data.Dto
{
    public class CandidateDto
    {
        public int IdCandidate { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
