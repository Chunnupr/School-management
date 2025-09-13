using System;

namespace SchoolManagementSystem.Core.Models
{
    public class License
    {
        public int Id { get; set; }

        // These properties should be encrypted before storing in the database.
        public string LicenseKey { get; set; }
        public string DeviceId { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
