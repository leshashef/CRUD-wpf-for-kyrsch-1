
using IlyaZenkinKyrsovaya.Models;
using IlyaZenkinKyrsovaya.ViewModels;
using IlyaZenkinKyrsovaya.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IlyaZenkinKyrsovaya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DepartmentContext contextDB;
        public MainWindow()
        {
            InitializeComponent();
            contextDB = new DepartmentContext();
            
            createTableReportCard();
            createTableChair();
            createTableStudent();
            createTableTeacher();
            createTableDiscipline();
        }

        private void createTableReportCard()
        {
            List<ViewRepordCard> viewRepordCards = new List<ViewRepordCard>();
          //  var reportCards = contextDB.ReportCard.Join(contextDB.Discipline,r=>r.DisciplineId, d=>d.Id, (r,d)=>  { r.Discipline = d; }).ToList();
            var reportCards = from reportCart in contextDB.ReportCard
                              join discipline in contextDB.Discipline on reportCart.DisciplineId equals discipline.Id
                              join teacher in contextDB.Teacher on reportCart.TeacherId equals teacher.Id
                              join student in contextDB.Student on reportCart.StudentId equals student.Id
                              select new
                              {
                                  Id = reportCart.Id,
                                  TeacherFIO = teacher.FirstName + " " + teacher.MiddleName + " " + teacher.LastName,
                                  StudentFIO = student.FirstName + " " + student.MiddleName + " " + student.LastName,
                                  Grades = reportCart.Grades,
                                  DisciplineName = discipline.NameDiscipline
                              };
             tableRepordCard.ItemsSource = null;
            foreach (var card in reportCards)
            {
                viewRepordCards.Add(new ViewRepordCard
                {
                    DisciplineName = card.DisciplineName,
                    Grades = card.Grades,
                    TeacherFIO = card.TeacherFIO,
                    StudentFIO = card.StudentFIO,
                    Id = card.Id
                }) ;
            }
            tableRepordCard.ItemsSource = viewRepordCards;
          
        }

        private void createTableChair()
        {
           List< Chair> chairs = contextDB.Chair.ToList();
            tableChair.ItemsSource = null;
            tableChair.ItemsSource = chairs;
            
        }
        private void createTableStudent()
        {
            List<Student> student = contextDB.Student.Include(x=>x.Chair).ToList();
            tableStudent.ItemsSource = null;
            foreach (var st in student)
            {
                tableStudent.Items.Add(new {
                Id = st.Id,
                StudFio = st.FirstName + " " + st.MiddleName + " " + st.LastName,
                Chair = st.Chair.NameChair,
                YearOfBirth = st.YearOfBirth,
                Gender = st.Gender,
                AddressStudent = st.AddressStudent,
                NumberPhone = st.NumberPhone,
                City = st.City
                });
            }

        }
        private void createTableTeacher()
        {
            List<Teacher> teacher = contextDB.Teacher.ToList();
            tableTeacher.ItemsSource = null;
            foreach (var st in teacher)
            {
                tableTeacher.Items.Add(new
                {
                    Id = st.Id,
                    TeacherFio = st.FirstName + " " + st.MiddleName + " " + st.LastName,
                    Chair = st.Chair.NameChair,
                    YearOfBirth = st.YearOfBirth,
                    YearStartWork = st.YearStartWork,
                    WorkExperience  = st.WorkExperience,
                    Post = st.Post,
                    Gender = st.Gender,
                    AddressTeacher = st.AddressTeacher,
                    NumberPhone = st.NumberPhone,
                    City = st.City
                });
            }
        }
        private void createTableDiscipline()
        {
            List<Discipline> discipline = contextDB.Discipline.ToList();
            tableDiscipline.ItemsSource = null;
            foreach (var st in discipline)
            {
                tableDiscipline.Items.Add(new
                {
                    Id = st.Id,
                    NameDiscipline = st.NameDiscipline,
                    Chair = st.Chair.NameChair,
                    LeadingTeacher = st.LeadingTeacher.FirstName + " "+ st.LeadingTeacher.MiddleName + " "+ st.LeadingTeacher.LastName,
                    CountHour = st.CountHour,
                    TypeOfControl = st.TypeOfControl,
                });
            }
        }
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
            e.Row.MinHeight = 20;
            e.Row.MaxHeight = 20;
        }

        private void Button_Click_Edit_reportcart(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            
            EditReportCard editReport = new EditReportCard(int.Parse(button.DataContext.ToString()));
          
            editReport.ShowDialog();

            createTableReportCard();
        }
        private void Button_Click_Delete_reportcart(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.DataContext.ToString());
            ConfirmDeleted confirmDeleted = new ConfirmDeleted();
            confirmDeleted.ShowDialog();
            if (confirmDeleted.delete)
            {
                contextDB.ReportCard.Remove(contextDB.ReportCard.FirstOrDefault(x => x.Id == id));
                contextDB.SaveChanges();
            }
            createTableReportCard();
        }

   

        private void CreateDiscipline(object sender, RoutedEventArgs e)
        {
            CreateDiscipline createDiscipline = new CreateDiscipline();
            createDiscipline.ShowDialog();
            createTableDiscipline();
        }

        private void CreateChair(object sender, RoutedEventArgs e)
        {
            CreateChair createChair = new CreateChair();
            createChair.ShowDialog();
            createTableChair();
        }

        private void CreateStudent(object sender, RoutedEventArgs e)
        {
            CreateStudent createStudent = new CreateStudent();
            createStudent.ShowDialog();
            createTableStudent();
        }

        private void CreateTeacher(object sender, RoutedEventArgs e)
        {
            CreateTeacher createTeacher = new CreateTeacher();
            createTeacher.ShowDialog();
            createTableTeacher();
        }

        private void CreateReportCard(object sender, RoutedEventArgs e)
        {
            CreateReportCard createReportCard = new CreateReportCard();
            createReportCard.ShowDialog();
            createTableReportCard();
        }

        private void Button_Click_Edit_Chair(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            EditChair editReport = new EditChair(int.Parse(button.DataContext.ToString()));

            editReport.ShowDialog();

            createTableChair();
        }

        private void Button_Click_Delete_Chair(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.DataContext.ToString());
            ConfirmDeleted confirmDeleted = new ConfirmDeleted();
            confirmDeleted.ShowDialog();
            if (confirmDeleted.delete)
            {
                contextDB.Chair.Remove(contextDB.Chair.FirstOrDefault(x => x.Id == id));
                contextDB.SaveChanges();
            }
            createTableChair();
        }

        private void Button_Click_Edit_Teacher(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            EditTeacher editReport = new EditTeacher(int.Parse(button.DataContext.ToString()));

            editReport.ShowDialog();

            createTableTeacher();
        }

        private void Button_Click_Delete_Teacher(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.DataContext.ToString());
            ConfirmDeleted confirmDeleted = new ConfirmDeleted();
            confirmDeleted.ShowDialog();
            if (confirmDeleted.delete)
            {
                contextDB.Teacher.Remove(contextDB.Teacher.FirstOrDefault(x => x.Id == id));
                contextDB.SaveChanges();
            }
            createTableTeacher();
        }

        private void Button_Click_Edit_Discipline(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            EditDiscipline editReport = new EditDiscipline(int.Parse(button.DataContext.ToString()));

            editReport.ShowDialog();

            createTableDiscipline();
        }

        private void Button_Click_Delete_Discipline(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.DataContext.ToString());
            ConfirmDeleted confirmDeleted = new ConfirmDeleted();
            confirmDeleted.ShowDialog();
            if (confirmDeleted.delete)
            {
                contextDB.Discipline.Remove(contextDB.Discipline.FirstOrDefault(x => x.Id == id));
                contextDB.SaveChanges();
            }
            createTableDiscipline();
        }

        private void Button_Click_Delete_Student(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.DataContext.ToString());
            ConfirmDeleted confirmDeleted = new ConfirmDeleted();
            confirmDeleted.ShowDialog();
            if (confirmDeleted.delete)
            {
                contextDB.Student.Remove(contextDB.Student.FirstOrDefault(x => x.Id == id));
                contextDB.SaveChanges();
            }
            createTableStudent();
        }

        private void Button_Click_Edit_Student(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            EditStudent editReport = new EditStudent(int.Parse(button.DataContext.ToString()));

            editReport.ShowDialog();

            createTableStudent();
        }
    }


}
