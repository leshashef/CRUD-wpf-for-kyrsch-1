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

namespace IlyaZenkinKyrsovaya.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateChair.xaml
    /// </summary>
    public partial class CreateChair : Window
    {
        DepartmentContext dbContext;
        public CreateChair()
        {
            dbContext = new DepartmentContext();
            InitializeComponent();

            CompleteField();
        }
        public void CompleteField()
        {
       
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var chair = new Chair();
            chair.CountTeacher = Convert.ToInt32(countTeacher.Text);
            chair.DeanFio = deanFio.Text;
            chair.NumberPhone = Convert.ToInt32(numberPhone.Text);
            chair.NumberRoom = Convert.ToInt32(numberRoom.Text);
            chair.NumberHousing = Convert.ToInt32(numberHousing.Text);
            chair.NameChair = nameChair.Text;
            dbContext.Chair.Add(chair);
            dbContext.SaveChanges();
            Close();
        }
    }
}
