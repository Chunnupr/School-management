using SQLite;

namespace SchoolManagementSystem.Models
{
    [Table("SchoolInfo")]
    public class SchoolInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public byte[] Logo { get; set; }
    }
}
