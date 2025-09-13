using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Interfaces
{
    public interface IDataService
    {
        Task ExportDataAsync(string filePath);
        Task ImportDataAsync(string filePath);
    }
}
