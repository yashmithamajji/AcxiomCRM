using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.Models
{
    public class FollowUp
    {
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; } = "";

        public string Lead { get; set; } = "";

        [Required]
        public DateTime FollowUpDate { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        public string AssignedTo { get; set; } = "";

        public string Notes { get; set; } = "";
    }
}
