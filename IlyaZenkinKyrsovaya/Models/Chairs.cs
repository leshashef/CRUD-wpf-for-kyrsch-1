using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IlyaZenkinKyrsovaya.Models
{
    public partial class Chairs
    {
        public int Id { get; set; }
        public int NumberRoom { get; set; }
        public int NumberHousing { get; set; }
        public int NumberPhone { get; set; }
        public int CountTeacher { get; set; }
        public string NameChair { get; set; }
        public string DeanFio { get; set; }
    }
}
