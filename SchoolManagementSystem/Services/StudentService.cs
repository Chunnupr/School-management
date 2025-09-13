using SchoolManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services
{
    public class StudentService
    {
        private readonly DatabaseService _dbService;

        public StudentService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        // Student Methods
        public async Task<List<Student>> GetStudentsAsync()
        {
            var conn = _dbService.GetConnection();
            return await conn.Table<Student>().ToListAsync();
        }

        public async Task<int> AddStudentAsync(Student student)
        {
            var conn = _dbService.GetConnection();
            return await conn.InsertAsync(student);
        }

        // Class Methods
        public async Task<List<Class>> GetClassesAsync()
        {
            var conn = _dbService.GetConnection();
            return await conn.Table<Class>().ToListAsync();
        }

        public async Task<int> AddClassAsync(Class newClass)
        {
            var conn = _dbService.GetConnection();
            return await conn.InsertAsync(newClass);
        }

        // Section Methods
        public async Task<List<Section>> GetSectionsAsync()
        {
            var conn = _dbService.GetConnection();
            return await conn.Table<Section>().ToListAsync();
        }

        // Subject Methods
        public async Task<List<Subject>> GetSubjectsAsync()
        {
            var conn = _dbService.GetConnection();
            return await conn.Table<Subject>().ToListAsync();
        }
    }
}
