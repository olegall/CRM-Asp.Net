using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class AccountVM
    {
        public int Id { get; set; }
        public int SelectedContractorId { get; set; }
        public int StatusId { get; set; }
        public IList<Contractor> Contractors { get; set; }
        public IList<AccountStatus> Statuses { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string Note { get; set; }
    }
}