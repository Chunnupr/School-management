using SQLite;
using System;

namespace SchoolManagementSystem.Models
{
    [Table("Students")]
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string AdmissionNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        // Contact Info
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Guardian Info
        public string GuardianName { get; set; }
        public string GuardianRelation { get; set; }
        public string GuardianPhone { get; set; }

        // Academic Info
        [Indexed]
        public int ClassId { get; set; }
        [Indexed]
        public int SectionId { get; set; }

        public DateTime AdmissionDate { get; set; }
    }
}
