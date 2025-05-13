using D8M7Q2_Sztgui_FF.Models;
using D8M7Q2_Sztgui_FF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace D8M7Q2_Sztgui_FF.Views
{
    public partial class StudentDetailWindow : Window
    {
        public StudentDetailWindow(Student student)
        {
            InitializeComponent();
            DataContext = student;
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FNTB.Text) || string.IsNullOrWhiteSpace(LNTB.Text) || string.IsNullOrWhiteSpace(CNTB.Text) || string.IsNullOrWhiteSpace(MNTB.Text) || string.IsNullOrWhiteSpace(ATB.Text))
            {
                MessageBox.Show("All fields must be filled.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}
