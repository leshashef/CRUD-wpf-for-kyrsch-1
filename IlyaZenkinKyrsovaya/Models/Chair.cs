using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IlyaZenkinKyrsovaya.Models
{
    public partial class Chair
    {
        public Chair()
        {
            Discipline = new HashSet<Discipline>();
            Student = new HashSet<Student>();
            Teacher = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string NameChair { get; set; }
        public string DeanFio { get; set; }
        public int NumberRoom { get; set; }
        public int NumberHousing { get; set; }
        public long NumberPhone { get; set; }
        public int CountTeacher { get; set; }

        public virtual ICollection<Discipline> Discipline { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
