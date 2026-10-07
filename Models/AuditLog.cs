using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.Models
{
    public class AuditLog
    {
        public int Id { get; set; }

        public string UserId { get; set; } = "";

        [Required]
        public string Action { get; set; } = "";

        public string EntityName { get; set; } = "";

        public string RecordId { get; set; } = "";

        public string OldValue { get; set; } = "";

        public string NewValue { get; set; } = "";

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string IpAddress { get; set; } = "";
    }
}