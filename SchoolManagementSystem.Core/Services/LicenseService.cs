using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Core.Data;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;
using System;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Services
{
    public class LicenseService : ILicenseService
    {
        private readonly ApplicationDbContext _context;

        public LicenseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ActivateLicenseAsync(string licenseKey, string deviceId)
        {
            // In a real application, we would call a cloud service to validate the license key
            // and get the expiry date. Here we will just simulate it.
            var expiryDate = DateTime.UtcNow.AddYears(1);

            // In a real application, we would encrypt the license data before storing it.
            var license = new License
            {
                LicenseKey = licenseKey,
                DeviceId = deviceId,
                ExpiryDate = expiryDate
            };

            _context.Licenses.Add(license);
            await _context.SaveChangesAsync();
        }

        public async Task<License> GetLicenseAsync()
        {
            // Assuming there is only one license per installation.
            return await _context.Licenses.FirstOrDefaultAsync();
        }

        public async Task<bool> ValidateLicenseAsync(string licenseKey)
        {
            var license = await GetLicenseAsync();
            if (license == null)
            {
                return false;
            }

            // In a real application, we would decrypt the license key before comparing.
            if (license.LicenseKey != licenseKey)
            {
                return false;
            }

            if (license.ExpiryDate < DateTime.UtcNow)
            {
                return false;
            }

            // In a real application, we would also validate the device ID.

            return true;
        }
    }
}
