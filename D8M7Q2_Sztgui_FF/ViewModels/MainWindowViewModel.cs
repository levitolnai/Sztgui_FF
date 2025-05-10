using D8M7Q2_Sztgui_FF.Models;
using D8M7Q2_Sztgui_FF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace D8M7Q2_Sztgui_FF.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public BindingList<Student> Students { get; set; } = new BindingList<Student>();

        public MainWindowViewModel() 
        {
            Students.Add(new Student("John", "Doe", "10A", new BindingList<Subject> { new Subject("Math", 5), new Subject("English", 4) }));
            Students.Add(new Student("Jane", "Smith", "10B", new BindingList<Subject> { new Subject("Math", 3), new Subject("English", 5) }));
            Students.Add(new Student("Alice", "Johnson", "10C", new BindingList<Subject> { new Subject("Math", 4), new Subject("English", 3) }));
            Students.Add(new Student("Bob", "Brown", "10D", new BindingList<Subject> { new Subject("Math", 2), new Subject("English", 4) }));
            Students.Add(new Student("Charlie", "Davis", "10E", new BindingList<Subject> { new Subject("Math", 5), new Subject("English", 5) }));
            Students.Add(new Student("David", "Wilson", "10F", new BindingList<Subject> { new Subject("Math", 4), new Subject("English", 2) }));


        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
