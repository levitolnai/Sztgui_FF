using D8M7Q2_Sztgui_FF.Models;
using D8M7Q2_Sztgui_FF.ViewModels;
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
    /// Interaction logic for StudentDetailWindow.xaml
    /// </summary>
    public partial class StudentDetailWindow : Window
    {
        public StudentDetailWindow(/*Student student*/)
        {
            InitializeComponent();
            //DataContext = new StudentDetailViewModel(student);
        }
    }
}
