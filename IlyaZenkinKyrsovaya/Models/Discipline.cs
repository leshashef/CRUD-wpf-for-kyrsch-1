using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IlyaZenkinKyrsovaya.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            ReportCard = new HashSet<ReportCard>();
        }

        public int Id { get; set; }
        public string NameDiscipline { get; set; }
        public int ChairId { get; set; }
        public int LeadingTeacherId { get; set; }
        public int CountHour { get; set; }
        public string TypeOfControl { get; set; }

        public virtual Chair Chair { get; set; }
        public virtual Teacher LeadingTeacher { get; set; }
        public virtual ICollection<ReportCard> ReportCard { get; set; }
    }
}
