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
using System.Windows;
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
            new Student() { ClassName = "1", FirstName = "Emily", LastName = "Taylor", Subjects = new BindingList<Subject> { new Subject("History", 4, 5), new Subject("Biology", 3, 4) }, MotherName = "Anna Taylor", Address = "7621 Pécs, Petőfi Sándor utca 12." },
            new Student() { ClassName = "2", FirstName = "Michael", LastName = "Clark", Subjects = new BindingList<Subject> { new Subject("Physics", 5, 4), new Subject("Chemistry", 4, 3), new Subject("Math", 5, 5) }, MotherName = "Laura Clark", Address = "7632 Pécs, Rákóczi utca 5." },
            new Student() { ClassName = "3", FirstName = "Sophia", LastName = "Evans", Subjects = new BindingList<Subject> { new Subject("English", 4, 4) }, MotherName = "Julia Evans", Address = "7624 Pécs, Kossuth Lajos utca 18." },
            new Student() { ClassName = "4", FirstName = "James", LastName = "Harris", Subjects = new BindingList<Subject> { new Subject("Math", 3, 4), new Subject("History", 5, 5), new Subject("Geography", 4, 3) }, MotherName = "Sarah Harris", Address = "7633 Pécs, Ady Endre utca 9." },
            new Student() { ClassName = "5", FirstName = "Olivia", LastName = "Walker", Subjects = new BindingList<Subject> { new Subject("Biology", 5, 5), new Subject("Chemistry", 4, 4) }, MotherName = "Emma Walker", Address = "7625 Pécs, Széchenyi tér 3." },
            new Student() { ClassName = "6", FirstName = "William", LastName = "Hall", Subjects = new BindingList<Subject> { new Subject("Physics", 3, 4), new Subject("Math", 5, 5), new Subject("English", 4, 3), new Subject("History", 5, 4) }, MotherName = "Sophia Hall", Address = "7634 Pécs, Hunyadi János utca 7." },
            new Student() { ClassName = "7", FirstName = "Isabella", LastName = "Adams", Subjects = new BindingList<Subject> { new Subject("Geography", 4, 4), new Subject("History", 5, 5) }, MotherName = "Olivia Adams", Address = "7626 Pécs, Zrínyi Miklós utca 11." },
            new Student() { ClassName = "8", FirstName = "Benjamin", LastName = "Nelson", Subjects = new BindingList<Subject> { new Subject("Math", 5, 5), new Subject("Physics", 4, 4), new Subject("Chemistry", 3, 3) }, MotherName = "Sophia Nelson", Address = "7635 Pécs, Táncsics Mihály utca 2." },
            new Student() { ClassName = "1", FirstName = "Charlotte", LastName = "Carter", Subjects = new BindingList<Subject> { new Subject("English", 5, 4), new Subject("Biology", 4, 3), new Subject("History", 5, 5), new Subject("Geography", 3, 4) }, MotherName = "Emily Carter", Address = "7627 Pécs, Deák Ferenc utca 6." },
            new Student() { ClassName = "2", FirstName = "Lucas", LastName = "Mitchell", Subjects = new BindingList<Subject> { new Subject("Math", 4, 4), new Subject("Physics", 5, 5) }, MotherName = "Sophia Mitchell", Address = "7636 Pécs, Bartók Béla utca 10." },

            };

            ClassNames = new ObservableCollection<string>
            {
                "All classes", "1", "2", "3", "4", "5", "6", "7", "8",
            };
            SelectedClassName = "All classes";

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

        public void EditStudent(Student student)
        {
            StudentDetailWindow editor = new StudentDetailWindow(student);

            if (editor.ShowDialog() == true)
            {
                FilteredStudents.Refresh();
            }
        }
        public void DeleteStudent(Student student)
        {
            if (Students.Contains(student))
            {
                Students.Remove(student);
                FilteredStudents.Refresh();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
