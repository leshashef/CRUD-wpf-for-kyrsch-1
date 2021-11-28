using IlyaZenkinKyrsovaya.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IlyaZenkinKyrsovaya.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditReportCard.xaml
    /// </summary>
    public partial class EditReportCard : Window
    {
        DepartmentContext dbContext;
        int Id;
        public EditReportCard(int id)
        {
            InitializeComponent();
            dbContext = new DepartmentContext();
            Id = id;
            CompleteField(id);
        }

        public void CompleteField(int id)
        {
          ReportCard reportCard = dbContext.ReportCard.Include(x => x.Student).Include(x => x.Teacher).Include(x => x.Discipline).FirstOrDefault(x => x.Id == id);
            if(reportCard == null)
            {
                return;
            }
            grade.Text = reportCard.Grades.ToString();
            studentBox.Items.Add(reportCard.Student.FirstName + " "+ reportCard.Student.MiddleName + " " + reportCard.Student.LastName +" - "+ reportCard.StudentId) ;
            studentBox.SelectedItem = reportCard.Student.FirstName + " " + reportCard.Student.MiddleName + " " + reportCard.Student.LastName + " - " + reportCard.StudentId;
            List<Student> otherStudents = dbContext.Student.Where(x=>x.Id != reportCard.StudentId).ToList();
            foreach(var st in otherStudents)
            {
                studentBox.Items.Add(st.FirstName + " " + st.MiddleName + " " + st.LastName + " - " + st.Id);
            }
            teacherBox.Items.Add(reportCard.Teacher.FirstName + " " + reportCard.Teacher.MiddleName + " " + reportCard.Teacher.LastName + " - " + reportCard.TeacherId);
            teacherBox.SelectedItem = reportCard.Teacher.FirstName + " " + reportCard.Teacher.MiddleName + " " + reportCard.Teacher.LastName + " - " + reportCard.TeacherId;
            List<Teacher> otherTeacer = dbContext.Teacher.Where(x => x.Id != reportCard.TeacherId).ToList();
            foreach (var st in otherTeacer)
            {
                teacherBox.Items.Add(st.FirstName + " " + st.MiddleName + " " + st.LastName + " - " + st.Id);
            }
            disciplineBox.Items.Add(reportCard.Discipline.NameDiscipline + " - " + reportCard.DisciplineId);
            disciplineBox.SelectedItem = reportCard.Discipline.NameDiscipline + " - " + reportCard.DisciplineId;
            List<Discipline> otherDic = dbContext.Discipline.Where(x => x.Id != reportCard.DisciplineId).ToList();
            foreach (var st in otherDic)
            {
                disciplineBox.Items.Add(st.NameDiscipline + " - " + st.Id);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReportCard reportCard = dbContext.ReportCard.Include(x => x.Student).Include(x => x.Teacher).Include(x => x.Discipline).FirstOrDefault(x => x.Id == Id);
            string[] student = studentBox.SelectedItem.ToString().Split(' ');
            string[] teacher = teacherBox.SelectedItem.ToString().Split(' ');
            string[] discipl = disciplineBox.SelectedItem.ToString().Split(' ');
            int grades = Convert.ToInt32(grade.Text);
            reportCard.StudentId = Convert.ToInt32(student[4]);
            reportCard.TeacherId = Convert.ToInt32(teacher[4]);
            reportCard.DisciplineId = Convert.ToInt32(discipl[discipl.Length - 1]);
            reportCard.Grades = grades;
            dbContext.SaveChanges();
            this.Close();
        }
    }
}
