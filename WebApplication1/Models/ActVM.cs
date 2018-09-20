using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ActVM
    {
        public int Id { get; set; }
        public int ContractorID { get; set; }
        public int SelectedContractorId { get; set; }
        public int StatusId { get; set; }
        public IList<Contractor> Contractors { get; set; }
        public IList<DocumentStatus> Statuses { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string Note { get; set; }
        public string ParentDocumentLink { get; set; }
    }
}