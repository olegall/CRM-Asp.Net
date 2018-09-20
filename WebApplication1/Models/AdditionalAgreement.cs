using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("aleynikov_AdditionalAgreements")]
    public class AdditionalAgreement: IDisposable
    {
        public int Id { get; set; }
        public int SelectedContractorID { get; set; }
        public int StatusID { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string Note { get; set; }
        public string ParentDocumentLink { get; set; }

        public void Dispose() { }
    }
}