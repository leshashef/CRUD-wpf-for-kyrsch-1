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
    /// Логика взаимодействия для CreateStudent.xaml
    /// </summary>
    public partial class CreateStudent : Window
    {
        DepartmentContext dbContext;
        public CreateStudent()
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
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
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
            dbContext.Student.Add(student);
            dbContext.SaveChanges();
            this.Close();
        }
    }
  
}
