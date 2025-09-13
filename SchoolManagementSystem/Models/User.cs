using SQLite;

namespace SchoolManagementSystem.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Indexed]
        public int RoleId { get; set; }
    }
}
