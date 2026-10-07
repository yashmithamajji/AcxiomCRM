using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [Phone]
        public string Phone { get; set; } = "";

        public string Company { get; set; } = "";

        public string Status { get; set; } = "Active";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}