using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("aleynikov_AccountStatuses")]
    public class AccountStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}