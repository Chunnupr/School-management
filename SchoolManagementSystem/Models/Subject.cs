using SQLite;

namespace SchoolManagementSystem.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(100)]
        public string SubjectName { get; set; }
    }
}
