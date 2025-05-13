using D8M7Q2_Sztgui_FF.Models;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for SubjectWindow.xaml
    /// </summary>
    public partial class SubjectWindow : Window
    {
        public Subject NewSubject { get; private set; }

        public SubjectWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SubjectNameTextBox.Text))
            {
                MessageBox.Show("Subject name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(FirstSemesterTextBox.Text, out int firstSemesterGrade))
            {
                MessageBox.Show("Invalid grade for first semester.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(SecondSemesterTextBox.Text, out int secondSemesterGrade))
            {
                MessageBox.Show("Invalid grade for second semester.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewSubject = new Subject(SubjectNameTextBox.Text, firstSemesterGrade, secondSemesterGrade);
            DialogResult = true;
            Close();
        }
    }
}
