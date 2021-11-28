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
    /// Логика взаимодействия для EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        DepartmentContext dbContext;
        int Id;
        public EditStudent(int id)
        {
            InitializeComponent();
            dbContext = new DepartmentContext();
            Id = id;
            CompleteField(id);
        }
        public void CompleteField(int id)
        {
            Student student = dbContext.Student.Include(x => x.Chair).FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return;
            }
            FirstName.Text = student.FirstName.ToString();
            MiddleName.Text = student.MiddleName.ToString();
            LastName.Text = student.LastName.ToString();
            Gender.Text = student.Gender.ToString();
            AddressStudent.Text = student.AddressStudent.ToString();
            NumberPhone.Text = student.NumberPhone.ToString();
            City.Text = student.City.ToString();
            Chair.Items.Add(student.Chair.NameChair + " - " + student.ChairId);
            Chair.SelectedItem = student.Chair.NameChair + " - " + student.ChairId;
            List<Chair> otherChair = dbContext.Chair.Where(x => x.Id != student.ChairId).ToList();
            foreach (var st in otherChair)
            {
                Chair.Items.Add(st.NameChair + " - " + st.Id);
            }
            YearOfBirth.SelectedDate = student.YearOfBirth;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student student = dbContext.Student.Include(x => x.Chair).FirstOrDefault(x => x.Id == Id);
            string[] Chairs = Chair.SelectedItem.ToString().Split(' ');

            student.ChairId = Convert.ToInt32(Chairs[Chairs.Length - 1]);
            student.FirstName = FirstName.Text;
            student.MiddleName = MiddleName.Text;
            student.LastName = LastName.Text;
            student.Gender = Gender.Text;
            student.City = City.Text;
            student.AddressStudent = AddressStudent.Text;
            student.NumberPhone = Convert.ToInt64(NumberPhone.Text);
            student.YearOfBirth = YearOfBirth.DisplayDate;

            dbContext.SaveChanges();
            this.Close();
        }
    }
}
