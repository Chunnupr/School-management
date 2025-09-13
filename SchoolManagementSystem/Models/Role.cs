using SQLite;

namespace SchoolManagementSystem.Models
{
    [Table("Roles")]
    public class Role
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(50)]
        public string RoleName { get; set; }
    }
}
