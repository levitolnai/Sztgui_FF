using D8M7Q2_Sztgui_FF.Models;
using D8M7Q2_Sztgui_FF.ViewModels;
using D8M7Q2_Sztgui_FF.Views;
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
            //Student newStudent = new Student();

            StudentDetailWindow editor = new StudentDetailWindow(/*newStudent*/);

            //if (editor.ShowDialog() == true && this.DataContext is MainWindowViewModel vm)
            //{
            //    vm.AddStudent(newStudent);
            //    lbox_left.Items.Refresh();
            //}
        }
    }
}