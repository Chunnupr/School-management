using SQLite;

namespace SchoolManagementSystem.Models
{
    [Table("Classes")]
    public class Class
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(100)]
        public string ClassName { get; set; }
    }
}
