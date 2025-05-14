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
    public partial class SubjectWindow : Window
    {
        private Subject _originalSubject;
        private Subject _tempSubject;

        public SubjectWindow(Subject subject)
        {
            InitializeComponent();
            _originalSubject = subject;
            _tempSubject = new Subject
            {
                Name = subject.Name,
                FirstSemester = subject.FirstSemester,
                SecondSemester = subject.SecondSemester
            };
            DataContext = _tempSubject;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SubjectNameTextBox.Text))
            {
                MessageBox.Show("Subject name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(FirstSemesterTextBox.Text))
            {
                if (!int.TryParse(FirstSemesterTextBox.Text, out int parsedFirstSemesterGrade) || parsedFirstSemesterGrade < 1 || parsedFirstSemesterGrade > 5)
                {
                    MessageBox.Show("First semester grade must be a number between 1 and 5, or left empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(SecondSemesterTextBox.Text))
            {
                if (!int.TryParse(SecondSemesterTextBox.Text, out int parsedSecondSemesterGrade) || parsedSecondSemesterGrade < 1 || parsedSecondSemesterGrade > 5)
                {
                    MessageBox.Show("Second semester grade must be a number between 1 and 5, or left empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            _originalSubject.Name = _tempSubject.Name;
            _originalSubject.FirstSemester = _tempSubject.FirstSemester;
            _originalSubject.SecondSemester = _tempSubject.SecondSemester;

            DialogResult = true;
            Close();
        }
    }
}
