using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("aleynikov_DocumentStatuses")]
    public class DocumentStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}