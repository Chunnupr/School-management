using SQLite;
using System;

namespace SchoolManagementSystem.Models
{
    [Table("FeePayments")]
    public class FeePayment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int StudentId { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Fine { get; set; }

        public decimal Discount { get; set; }

        public string Remarks { get; set; }
    }
}
