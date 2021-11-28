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
    /// Логика взаимодействия для EditChair.xaml
    /// </summary>
    public partial class EditChair : Window
    {
        DepartmentContext dbContext;
        int Id;
        public EditChair(int id)
        {
            InitializeComponent();
            dbContext = new DepartmentContext();
            Id = id;
            CompleteField(id);
        }

        public void CompleteField(int id)
        {
            var chair = dbContext.Chair.FirstOrDefault(x => x.Id == id);
            nameChair.Text = chair.NameChair.ToString();
            deanFio.Text = chair.DeanFio.ToString();
            numberRoom.Text = chair.NumberRoom.ToString();
            numberHousing.Text = chair.NumberHousing.ToString();
            numberPhone.Text = chair.NumberPhone.ToString();
            countTeacher.Text = chair.CountTeacher.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var chair = dbContext.Chair.FirstOrDefault(x => x.Id == Id);
            chair.CountTeacher = Convert.ToInt32(countTeacher.Text);
            chair.DeanFio =deanFio.Text;
            chair.NumberPhone = Convert.ToInt32(numberPhone.Text);
            chair.NumberRoom = Convert.ToInt32(numberRoom.Text);
            chair.NumberHousing = Convert.ToInt32(numberHousing.Text);
            chair.NameChair = nameChair.Text;
            dbContext.SaveChanges();
            Close();
        }
    }
}
