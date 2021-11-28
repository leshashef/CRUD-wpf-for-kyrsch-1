using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IlyaZenkinKyrsovaya.Models
{
    public partial class Student
    {
        public Student()
        {
            ReportCard = new HashSet<ReportCard>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int ChairId { get; set; }
        public DateTime YearOfBirth { get; set; }
        public string Gender { get; set; }
        public string AddressStudent { get; set; }
        public long NumberPhone { get; set; }
        public string City { get; set; }

        public virtual Chair Chair { get; set; }
        public virtual ICollection<ReportCard> ReportCard { get; set; }
    }
}
