using System;

namespace SchoolManagementSystem.Core.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}
