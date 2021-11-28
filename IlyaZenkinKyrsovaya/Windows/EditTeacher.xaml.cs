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
    /// Логика взаимодействия для EditTeacher.xaml
    /// </summary>
    public partial class EditTeacher : Window
    {
        DepartmentContext dbContext;
        int Id;
        public EditTeacher(int id)
        {
            InitializeComponent();
            dbContext = new DepartmentContext();
            Id = id;
            CompleteField(id);
        }
        public void CompleteField(int id)
        {
            Teacher teacher = dbContext.Teacher.Include(x => x.Chair).FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return;
            }
            FirstName.Text = teacher.FirstName.ToString();
            MiddleName.Text = teacher.MiddleName.ToString();
            LastName.Text = teacher.LastName.ToString();
            WorkExperience.Text = teacher.WorkExperience.ToString();
            Post.Text = teacher.Post.ToString();
            Gender.Text = teacher.Gender.ToString();
            AddressTeacher.Text = teacher.AddressTeacher.ToString();
            NumberPhone.Text = teacher.NumberPhone.ToString();
            City.Text = teacher.City.ToString();
            Chair.Items.Add(teacher.Chair.NameChair + " - " + teacher.ChairId);
            Chair.SelectedItem = teacher.Chair.NameChair + " - " + teacher.ChairId;
            List<Chair> otherChair = dbContext.Chair.Where(x => x.Id != teacher.ChairId).ToList();
            foreach (var st in otherChair)
            {
                Chair.Items.Add(st.NameChair + " - " + st.Id);
            }
            YearOfBirth.SelectedDate = teacher.YearOfBirth;
            YearStartWork.SelectedDate = teacher.YearStartWork;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = dbContext.Teacher.Include(x => x.Chair).FirstOrDefault(x => x.Id == Id);
            string[] Chairs = Chair.SelectedItem.ToString().Split(' ');

            teacher.ChairId = Convert.ToInt32(Chairs[Chairs.Length-1]);
            teacher.FirstName = FirstName.Text;
            teacher.MiddleName = MiddleName.Text;
            teacher.LastName = LastName.Text;
            teacher.WorkExperience =Convert.ToInt32( WorkExperience.Text);
            teacher.Post = Post.Text;
            teacher.Gender = Gender.Text;
            teacher.City = City.Text;
            teacher.AddressTeacher = AddressTeacher.Text;
            teacher.NumberPhone = Convert.ToInt64( NumberPhone.Text);
            teacher.YearOfBirth = YearOfBirth.DisplayDate;
            teacher.YearStartWork = YearStartWork.DisplayDate;

            dbContext.SaveChanges();
            this.Close();
        }
    }
}
