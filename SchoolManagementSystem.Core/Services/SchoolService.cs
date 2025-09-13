using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Core.Data;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;
using System;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ApplicationDbContext _context;

        public SchoolService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<School> CreateSchoolAsync(School school)
        {
            // Assuming only one school can be created.
            if (await _context.Schools.AnyAsync())
            {
                throw new InvalidOperationException("A school has already been configured.");
            }

            _context.Schools.Add(school);
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<School> GetSchoolAsync()
        {
            return await _context.Schools.FirstOrDefaultAsync();
        }

        public async Task UpdateSchoolAsync(School school)
        {
            _context.Entry(school).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
