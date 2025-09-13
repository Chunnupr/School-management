using SchoolManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services
{
    public class FinanceService
    {
        private readonly DatabaseService _dbService;

        public FinanceService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        // Fee Structure Methods
        public async Task<List<FeeStructure>> GetFeeStructuresAsync(int classId)
        {
            var conn = _dbService.GetConnection();
            return await conn.Table<FeeStructure>().Where(fs => fs.ClassId == classId).ToListAsync();
        }

        public async Task<int> AddFeeStructureAsync(FeeStructure feeStructure)
        {
            var conn = _dbService.GetConnection();
            return await conn.InsertAsync(feeStructure);
        }

        // Fee Payment Methods
        public async Task<List<FeePayment>> GetPaymentsForStudentAsync(int studentId)
        {
            var conn = _dbService.GetConnection();
            return await conn.Table<FeePayment>().Where(fp => fp.StudentId == studentId).ToListAsync();
        }

        public async Task<int> AddPaymentAsync(FeePayment payment)
        {
            var conn = _dbService.GetConnection();
            return await conn.InsertAsync(payment);
        }
    }
}
