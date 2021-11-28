using IlyaZenkinKyrsovaya.Models;
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
    /// Логика взаимодействия для CreateDiscipline.xaml
    /// </summary>
    public partial class CreateDiscipline : Window
    {
        DepartmentContext dbContext;
        public CreateDiscipline()
        {
            dbContext = new DepartmentContext();
            InitializeComponent();

            CompleteField();
        }
        public void CompleteField()
        {
            List<Chair> otherChair = dbContext.Chair.ToList();
            foreach (var st in otherChair)
            {
                Chair.Items.Add(st.NameChair + " - " + st.Id);
            }
            List<Teacher> otherTeacher = dbContext.Teacher.ToList();
            foreach (var st in otherTeacher)
            {
                LeadingTeacher.Items.Add(st.FirstName+ " "+ st.MiddleName + " " + st.LastName + " - " + st.Id);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Discipline discipline = new Discipline();
            string[] Chairs = Chair.SelectedItem.ToString().Split(' ');
            string[] Teachers = LeadingTeacher.SelectedItem.ToString().Split(' ');

            discipline.ChairId = Convert.ToInt32(Chairs[Chairs.Length - 1]);
            discipline.LeadingTeacherId = Convert.ToInt32(Teachers[Teachers.Length - 1]);

            discipline.NameDiscipline = NameDiscipline.Text;
            discipline.CountHour = Convert.ToInt32(CountHour.Text);
            discipline.TypeOfControl = TypeOfControl.Text;
            dbContext.Discipline.Add(discipline);
            dbContext.SaveChanges();
            this.Close();
        }
    }
}
