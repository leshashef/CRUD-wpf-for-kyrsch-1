using IlyaZenkinKyrsovaya.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IlyaZenkinKyrsovaya.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateReportCard.xaml
    /// </summary>
    public partial class CreateReportCard : Window
    {
        DepartmentContext dbContext;
        public CreateReportCard()
        { 
            dbContext = new DepartmentContext();
            InitializeComponent();
           
            CompleteField();
        }

        public void CompleteField()
        {
            List<Student> otherStudents = dbContext.Student.ToList();
            foreach (var st in otherStudents)
            {
                studentBox.Items.Add(st.FirstName + " " + st.MiddleName + " " + st.LastName + " - " + st.Id);
            }
            List<Teacher> otherTeacer = dbContext.Teacher.ToList();
            foreach (var st in otherTeacer)
            {
                teacherBox.Items.Add(st.FirstName + " " + st.MiddleName + " " + st.LastName + " - " + st.Id);
            }
            List<Discipline> otherDic = dbContext.Discipline.ToList();
            foreach (var st in otherDic)
            {
                disciplineBox.Items.Add(st.NameDiscipline + " - " + st.Id);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReportCard reportCard = new ReportCard();
            string[] student = studentBox.SelectedItem.ToString().Split(' ');
            string[] teacher = teacherBox.SelectedItem.ToString().Split(' ');
            string[] discipl = disciplineBox.SelectedItem.ToString().Split(' ');
            int grades = Convert.ToInt32(grade.Text);
            reportCard.StudentId = Convert.ToInt32(student[4]);
            reportCard.TeacherId = Convert.ToInt32(teacher[4]);
            reportCard.DisciplineId = Convert.ToInt32(discipl[discipl.Length-1]);
            reportCard.Grades = grades;
            dbContext.ReportCard.Add(reportCard);
            dbContext.SaveChanges();
            this.Close();
        }
    }
}
