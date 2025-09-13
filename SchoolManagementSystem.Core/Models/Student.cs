using System;

namespace SchoolManagementSystem.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime AdmissionDate { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
