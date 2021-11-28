using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IlyaZenkinKyrsovaya.Models
{
    public partial class ReportCard
    {
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int? Grades { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
