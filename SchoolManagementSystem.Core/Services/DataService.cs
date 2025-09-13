using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Core.Data;
using SchoolManagementSystem.Core.Interfaces;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Services
{
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _context;

        public DataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ExportDataAsync(string filePath)
        {
            var allData = new
            {
                Users = await _context.Users.ToListAsync(),
                Schools = await _context.Schools.ToListAsync(),
                Licenses = await _context.Licenses.ToListAsync(),
                Students = await _context.Students.ToListAsync(),
                Classes = await _context.Classes.ToListAsync(),
                Sections = await _context.Sections.ToListAsync(),
                Fees = await _context.Fees.ToListAsync(),
                Invoices = await _context.Invoices.ToListAsync(),
                Payments = await _context.Payments.ToListAsync()
            };

            var jsonData = JsonSerializer.Serialize(allData);

            // In a real application, we would use a strong encryption algorithm like AES.
            // For now, we will just write the plain JSON data.
            var encryptedData = System.Text.Encoding.UTF8.GetBytes(jsonData);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create))
            {
                var dataEntry = archive.CreateEntry("data.json");
                using (var entryStream = dataEntry.Open())
                {
                    await entryStream.WriteAsync(encryptedData, 0, encryptedData.Length);
                }

                // In a real application, we would calculate a checksum of the encrypted data.
                // For now, we will just write a dummy checksum.
                var checksum = "dummy_checksum";
                var checksumEntry = archive.CreateEntry("checksum.txt");
                using (var entryStream = checksumEntry.Open())
                using (var streamWriter = new StreamWriter(entryStream))
                {
                    await streamWriter.WriteAsync(checksum);
                }
            }
        }

        public Task ImportDataAsync(string filePath)
        {
            // Implementation of the import logic will be done later.
            throw new System.NotImplementedException();
        }
    }
}
