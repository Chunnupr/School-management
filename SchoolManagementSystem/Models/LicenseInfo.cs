using SQLite;
using System;

namespace SchoolManagementSystem.Models
{
    [Table("LicenseInfo")]
    public class LicenseInfo
    {
        [PrimaryKey]
        public string LicenseKey { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }
    }
}
