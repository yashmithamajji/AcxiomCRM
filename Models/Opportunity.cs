using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.Models
{
    public class Opportunity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [Required]
        public string Customer { get; set; } = "";

        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Range(0, 100)]
        public int Probability { get; set; }

        public string Stage { get; set; } = "Prospecting";

        public string Status { get; set; } = "Open";

        public DateTime ExpectedCloseDate { get; set; } = DateTime.Now.AddDays(30);

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}