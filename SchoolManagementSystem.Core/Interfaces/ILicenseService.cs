using SchoolManagementSystem.Core.Models;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Interfaces
{
    public interface ILicenseService
    {
        Task<License> GetLicenseAsync();
        Task<bool> ValidateLicenseAsync(string licenseKey);
        Task ActivateLicenseAsync(string licenseKey, string deviceId);
    }
}
