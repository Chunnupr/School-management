using SQLite;

namespace SchoolManagementSystem.Models
{
    [Table("Sections")]
    public class Section
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(50)]
        public string SectionName { get; set; }
    }
}
