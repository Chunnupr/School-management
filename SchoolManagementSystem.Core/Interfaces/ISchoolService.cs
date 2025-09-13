using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.Core.Interfaces
{
    public interface ISchoolService
    {
        Task<School> GetSchoolAsync();
        Task<School> CreateSchoolAsync(School school);
        Task UpdateSchoolAsync(School school);
    }
}
