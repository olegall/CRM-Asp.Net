using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class EmailVM
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateBack { get; set; }
        public string Description { get; set; }
        public string DeliverySystem { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingNumberBack { get; set; }
        public IList<EmailStatus> Statuses { get; set; }
    }
}