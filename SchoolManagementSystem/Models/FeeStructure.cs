using SQLite;

namespace SchoolManagementSystem.Models
{
    [Table("FeeStructures")]
    public class FeeStructure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int ClassId { get; set; }

        public string FeeComponent { get; set; } // e.g., "Tuition Fee", "Library Fee"

        public decimal Amount { get; set; }
    }
}
