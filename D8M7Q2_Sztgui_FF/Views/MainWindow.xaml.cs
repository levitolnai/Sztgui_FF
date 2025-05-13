using D8M7Q2_Sztgui_FF.Models;
using D8M7Q2_Sztgui_FF.ViewModels;
using D8M7Q2_Sztgui_FF.Views;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace D8M7Q2_Sztgui_FF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void Add_student_click(object sender, RoutedEventArgs e)
        {
            Student newStud = new Student();

            StudentDetailWindow editor = new StudentDetailWindow(newStud);

            if (editor.ShowDialog() == true && this.DataContext is MainWindowViewModel vm)
            {
                vm.AddStudent(newStud);
                FilteredStudentsListBox.Items.Refresh();
            }
        }

        private void Edit_student_click(object sender, RoutedEventArgs e)
        {
            //if no student is selected, open a messagebox, if selected, open the editor
            if (FilteredStudentsListBox.SelectedItem == null)
            {
                MessageBox.Show("Select a student!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (DataContext is MainWindowViewModel vm && FilteredStudentsListBox.SelectedItem is Student selectedStudent)
            {
                vm.EditStudent(selectedStudent);
            }
            
        }

        private void Delete_student_click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MainWindowViewModel vm && FilteredStudentsListBox.SelectedItem is Student selectedStudent)
            {
                vm.DeleteStudent(selectedStudent);
            }
        }

        private void Add_subject_click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;
            viewModel?.AddSubject();
        }

        private void Edit_subject_click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_subject_click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainWindowViewModel;
            viewModel?.DeleteSubject();
        }
    }
}