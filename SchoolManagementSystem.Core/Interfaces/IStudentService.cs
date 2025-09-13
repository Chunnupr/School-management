using SchoolManagementSystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<ICollection<Student>> GetStudentsAsync();
        Task<Student> CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
    }
}
