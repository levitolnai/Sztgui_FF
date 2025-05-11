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
using System.Windows.Data;
using System.Windows.Input;

namespace D8M7Q2_Sztgui_FF.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _selectedClassName;
        private ObservableCollection<Student> _students;
        private ICollectionView _filteredStudents;

        public ObservableCollection<string> ClassNames { get; set; }
        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView FilteredStudents
        {
            get => _filteredStudents;
            set
            {
                _filteredStudents = value;
                OnPropertyChanged();
            }
        }

        public string SelectedClassName
        {
            get => _selectedClassName;
            set
            {
                _selectedClassName = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }
        public MainWindowViewModel()
        {
            Students = new ObservableCollection<Student>()
            {
            new Student() { ClassName = "1", FirstName = "John", LastName = "Doe", Subjects = new BindingList<Subject> { new Subject("Math", 5, 3), new Subject("English", 4, 3) } },
            new Student() { ClassName = "2", FirstName = "Jane", LastName = "Smith", Subjects = new BindingList<Subject> { new Subject("Math", 3, 3), new Subject("English", 5, 3) } },
            new Student() { ClassName = "2", FirstName = "Alice", LastName = "Johnson", Subjects = new BindingList<Subject> { new Subject("Math", 4, 3), new Subject("English", 3, 3) } },
            new Student() { ClassName = "4", FirstName = "Bob", LastName = "Brown", Subjects = new BindingList<Subject> { new Subject("Math", 2, 3), new Subject("English", 4, 3) } },
            new Student() { ClassName = "8", FirstName = "Charlie", LastName = "Davis", Subjects = new BindingList<Subject> { new Subject("Math", 5, 3), new Subject("English", 5, 3) } },
            new Student() { ClassName = "8", FirstName = "David", LastName = "Wilson", Subjects = new BindingList<Subject> { new Subject("Math", 4, 3), new Subject("English", 2, 3) } },
            };
            //Students = new ObservableCollection<Student>();
            //Students.Add(new Student("John", "Doe", "1", new BindingList<Subject> { new Subject("Math", 5, 3), new Subject("English", 4, 3) }));
            //Students.Add(new Student("Jane", "Smith", "2", new BindingList<Subject> { new Subject("Math", 3, 3), new Subject("English", 5, 3) }));
            //Students.Add(new Student("Alice", "Johnson", "2", new BindingList<Subject> { new Subject("Math", 4, 3), new Subject("English", 3, 3) }));
            //Students.Add(new Student("Bob", "Brown", "4", new BindingList<Subject> { new Subject("Math", 2, 3), new Subject("English", 4, 3) }));
            //Students.Add(new Student("Charlie", "Davis", "8", new BindingList<Subject> { new Subject("Math", 5, 3), new Subject("English", 5, 3) }));
            //Students.Add(new Student("David", "Wilson", "8", new BindingList<Subject> { new Subject("Math", 4, 3), new Subject("English", 2, 3) }));

            ClassNames = new ObservableCollection<string>
            {
                "All classes", "1", "2", "3", "4", "5", "6", "7", "8",
            };

            FilteredStudents = CollectionViewSource.GetDefaultView(Students);

        }

        public void ApplyFilter()
        {
            if (FilteredStudents == null) return;

            FilteredStudents.Filter = student =>
            {
                var s = student as Student;
                // If "All classes" is selected or SelectedClassName is empty, show all students
                return s != null && (SelectedClassName == "All classes" || string.IsNullOrEmpty(SelectedClassName) || s.ClassName == SelectedClassName);
            };

            FilteredStudents.Refresh();
        }


        public void AddStudent(Student stud)
        {
            Students.Add(stud);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
