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
