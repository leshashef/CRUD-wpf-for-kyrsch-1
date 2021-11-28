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
    /// Логика взаимодействия для CreateTeacher.xaml
    /// </summary>
    public partial class CreateTeacher : Window
    {
        DepartmentContext dbContext;
        public CreateTeacher()
        {
            InitializeComponent();
            dbContext = new DepartmentContext();
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
            Teacher teacher = new Teacher();
            string[] Chairs = Chair.SelectedItem.ToString().Split(' ');

            teacher.ChairId = Convert.ToInt32(Chairs[Chairs.Length - 1]);
            teacher.FirstName = FirstName.Text;
            teacher.MiddleName = MiddleName.Text;
            teacher.LastName = LastName.Text;
            teacher.WorkExperience = Convert.ToInt32(WorkExperience.Text);
            teacher.Post = Post.Text;
            teacher.Gender = Gender.Text;
            teacher.City = City.Text;
            teacher.AddressTeacher = AddressTeacher.Text;
            teacher.NumberPhone = Convert.ToInt64(NumberPhone.Text);
            teacher.YearOfBirth = YearOfBirth.DisplayDate;
            teacher.YearStartWork = YearStartWork.DisplayDate;
            dbContext.Teacher.Add(teacher);
            dbContext.SaveChanges();
            this.Close();
        }
    }
}
