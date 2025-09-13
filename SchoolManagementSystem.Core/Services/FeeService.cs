using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Core.Data;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Services
{
    public class FeeService : IFeeService
    {
        private readonly ApplicationDbContext _context;

        public FeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Fee> CreateFeeAsync(Fee fee)
        {
            _context.Fees.Add(fee);
            await _context.SaveChangesAsync();
            return fee;
        }

        public async Task DeleteFeeAsync(int id)
        {
            var fee = await _context.Fees.FindAsync(id);
            if (fee != null)
            {
                _context.Fees.Remove(fee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Fee> GetFeeByIdAsync(int id)
        {
            return await _context.Fees.FindAsync(id);
        }

        public async Task<ICollection<Fee>> GetFeesByStudentAsync(int studentId)
        {
            return await _context.Fees.Where(f => f.StudentId == studentId).ToListAsync();
        }

        public async Task<Payment> ProcessPaymentAsync(int invoiceId, decimal amount)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);
            if (invoice == null)
            {
                throw new ArgumentException("Invoice not found.", nameof(invoiceId));
            }

            var payment = new Payment
            {
                InvoiceId = invoiceId,
                Amount = amount,
                PaymentDate = DateTime.UtcNow
            };

            _context.Payments.Add(payment);

            var fee = await _context.Fees.FindAsync(invoice.FeeId);
            if (fee != null)
            {
                // This is a simplified logic. In a real application, we would need to handle partial payments.
                if (payment.Amount >= fee.Amount)
                {
                    fee.IsPaid = true;
                }
            }

            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task UpdateFeeAsync(Fee fee)
        {
            _context.Entry(fee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
