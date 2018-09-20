using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("aleynikov_Emails")]
    public class Email: IDisposable
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateBack { get; set; }
        public string Description { get; set; }
        public string DeliverySystem  { get; set; }
        public string TrackingNumber { get; set; }
        public int StatusID  { get; set; }
        public string TrackingNumberBack { get; set; }

        public void Dispose() { }
    }
}