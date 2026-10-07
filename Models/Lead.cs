using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.Models
{
    public class Lead
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        public string Company { get; set; } = "";

        public string Status { get; set; } = "New";

        public string AssignedTo { get; set; } = "";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}