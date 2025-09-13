using System;

namespace SchoolManagementSystem.Core.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int FeeId { get; set; }
        public Fee Fee { get; set; }

        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
    }
}
