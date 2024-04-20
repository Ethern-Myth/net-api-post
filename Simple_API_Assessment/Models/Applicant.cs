using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple_API_Assessment.Models
{
    public class Applicant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public virtual IList<Skill> Skills { get; set; }
    }

    public class ApplicantDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
