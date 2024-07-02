using Microsoft.EntityFrameworkCore;
using Pandape.Data.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandape.Data.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Surname { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        public DateTime InsertDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public ICollection<CandidateExperience> Experiences { get; set; }
    }
}