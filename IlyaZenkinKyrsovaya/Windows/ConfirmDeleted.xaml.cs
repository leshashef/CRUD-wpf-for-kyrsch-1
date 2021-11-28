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
    /// Логика взаимодействия для ConfirmDeleted.xaml
    /// </summary>
    public partial class ConfirmDeleted : Window
    {
        public bool delete = false;
        public ConfirmDeleted()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            delete = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            delete = false;
            Close();
        }
    }
}
