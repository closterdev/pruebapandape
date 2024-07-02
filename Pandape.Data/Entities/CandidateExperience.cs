using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pandape.Data.Entities
{
    public class CandidateExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidateExperience { get; set; }

        [MaxLength(100)]
        public string Company { get; set; }

        [MaxLength(100)]
        public string Job { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Column(TypeName = "numeric(8,2)")]
        public decimal Salary { get; set; }

        [Required]
        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public DateTime InsertDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        [ForeignKey("Candidate")]
        public int IdCandidate { get; set; }

        public virtual Candidate Candidates { get; set; }
    }
}