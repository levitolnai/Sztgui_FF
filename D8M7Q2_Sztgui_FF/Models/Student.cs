using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8M7Q2_Sztgui_FF.Models
{
    public class Student : INotifyPropertyChanged
    {
        private string id;
        private string firstName;
        private string lastName;
        private ObservableCollection<Subject> subjects;

        public string Id
        {
            get => id;
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }
        public string FirstName
        {
            get => firstName;
            set { firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }
        public string LastName
        {
            get => lastName;
            set { lastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        public ObservableCollection<Subject> Subjects
        {
            get => subjects;
            set { subjects = value; OnPropertyChanged(nameof(Subjects)); }
        }
        public Student(string firstName, string lastName)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            Subjects = new ObservableCollection<Subject>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
    }
}
