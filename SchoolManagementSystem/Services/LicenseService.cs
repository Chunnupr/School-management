using SchoolManagementSystem.Models;
using System;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services
{
    public class LicenseService
    {
        private readonly DatabaseService _dbService;
        private const string ValidLicenseKey = "VALID-LICENSE-KEY"; // Mock license key

        public LicenseService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> ValidateLicenseAsync(string licenseKey)
        {
            // In a real app, this would make a secure call to a cloud server.
            // For now, we'll just mock the validation.
            if (licenseKey == ValidLicenseKey)
            {
                var licenseInfo = new LicenseInfo
                {
                    LicenseKey = licenseKey,
                    ExpirationDate = DateTime.UtcNow.AddYears(1),
                    IsActive = true
                };

                var conn = _dbService.GetConnection();
                await conn.InsertOrReplaceAsync(licenseInfo);
                return true;
            }
            return false;
        }

        public async Task<LicenseInfo> GetLicenseAsync()
        {
            var conn = _dbService.GetConnection();
            // Assuming only one license is ever stored
            return await conn.Table<LicenseInfo>().FirstOrDefaultAsync();
        }

        public async Task<bool> IsLicenseValidAsync()
        {
            var license = await GetLicenseAsync();
            if (license == null || !license.IsActive)
            {
                return false;
            }

            return license.ExpirationDate > DateTime.UtcNow;
        }
    }
}
