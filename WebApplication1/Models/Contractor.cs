using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("aleynikov_Contractors")]
    public class Contractor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
    }
}