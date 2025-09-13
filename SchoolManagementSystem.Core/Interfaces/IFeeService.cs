using SchoolManagementSystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Interfaces
{
    public interface IFeeService
    {
        Task<Fee> GetFeeByIdAsync(int id);
        Task<ICollection<Fee>> GetFeesByStudentAsync(int studentId);
        Task<Fee> CreateFeeAsync(Fee fee);
        Task UpdateFeeAsync(Fee fee);
        Task DeleteFeeAsync(int id);
        Task<Payment> ProcessPaymentAsync(int invoiceId, decimal amount);
    }
}
