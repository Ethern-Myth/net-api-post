using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple_API_Assessment.Models
{
    public class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
    }

    public class SkillDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required int ApplicantId { get; set; }
    }
}
