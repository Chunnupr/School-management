using SQLite;
using System;

namespace SchoolManagementSystem.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int StudentId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } // e.g., "Paid", "Unpaid"
    }
}
