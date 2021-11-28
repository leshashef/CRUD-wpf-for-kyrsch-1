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
    /// Логика взаимодействия для EditDiscipline.xaml
    /// </summary>
    public partial class EditDiscipline : Window
    {
        DepartmentContext dbContext;
        int Id;
        public EditDiscipline(int id)
        {
            InitializeComponent();
            dbContext = new DepartmentContext();
            Id = id;
            CompleteField(id);
        }

        public void CompleteField(int id)
        {
            Discipline discipline = dbContext.Discipline.Include(x=>x.LeadingTeacher).Include(x => x.Chair).FirstOrDefault(x => x.Id == id);
            if (discipline == null)
            {
                return;
            }
            NameDiscipline.Text = discipline.NameDiscipline.ToString();
            CountHour.Text = discipline.CountHour.ToString();
            TypeOfControl.Text = discipline.TypeOfControl.ToString();
            Chair.Items.Add(discipline.Chair.NameChair + " - " + discipline.ChairId);
            Chair.SelectedItem = discipline.Chair.NameChair + " - " + discipline.ChairId;
            List<Chair> otherChair = dbContext.Chair.Where(x => x.Id != discipline.ChairId).ToList();
            foreach (var st in otherChair)
            {
                Chair.Items.Add(st.NameChair + " - " + st.Id);
            }
            LeadingTeacher.Items.Add( discipline.LeadingTeacher.FirstName + " " + discipline.LeadingTeacher.MiddleName + " " + discipline.LeadingTeacher.LastName + " - " + discipline.LeadingTeacherId);
            LeadingTeacher.SelectedItem = discipline.LeadingTeacher.FirstName + " " + discipline.LeadingTeacher.MiddleName + " " + discipline.LeadingTeacher.LastName + " - " + discipline.LeadingTeacherId;
            List<Teacher> otherTeacher = dbContext.Teacher.Where(x => x.Id != discipline.LeadingTeacherId).ToList();
            foreach (var st in otherTeacher)
            {
                Chair.Items.Add(st.FirstName + " " + st.MiddleName + " " + st.LastName + " - " + st.Id);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Discipline discipline = dbContext.Discipline.Include(x => x.LeadingTeacher).Include(x => x.Chair).FirstOrDefault(x => x.Id == Id);
            string[] Chairs = Chair.SelectedItem.ToString().Split(' ');
            string[] Teachers = LeadingTeacher.SelectedItem.ToString().Split(' ');

            discipline.ChairId = Convert.ToInt32(Chairs[Chairs.Length - 1]);
            discipline.LeadingTeacherId = Convert.ToInt32(Teachers[Teachers.Length - 1]);

            discipline.NameDiscipline = NameDiscipline.Text;
            discipline.CountHour =Convert.ToInt32( CountHour.Text);
            discipline.TypeOfControl = TypeOfControl.Text;

            dbContext.SaveChanges();
            this.Close();
        }
    }
}
