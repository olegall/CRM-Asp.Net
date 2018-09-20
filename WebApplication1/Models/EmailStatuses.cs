using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("aleynikov_EmailStatuses")]
    public class EmailStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}