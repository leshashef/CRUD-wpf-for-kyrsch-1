using System;
using System.Collections.Generic;
using System.Text;

namespace IlyaZenkinKyrsovaya.ViewModels
{
    class ViewRepordCard
    {
        public int Id { get; set; }
        public string DisciplineName { get; set; }
        public string StudentFIO { get; set; }
        public string TeacherFIO { get; set; }
        public int? Grades { get; set; }
    }
}
