using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("aleynikov_Accounts")]
    public class Account : IDisposable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public int SelectedContractorID { get; set; }
        public string Note { get; set; }
        public int StatusID { get; set; }

        public void Dispose() { }
    }
}