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
        private string firstName = "";
        private string lastName = "";
        private string className = "";
        private BindingList<Subject> subjects = new BindingList<Subject>();
        private string motherName = "";
        private string address = "";

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
        public string ClassName
        {
            get => className;
            set { className = value; OnPropertyChanged(nameof(ClassName)); }
        }
        public BindingList<Subject> Subjects
        {
            get => subjects;
            set { subjects = value; OnPropertyChanged(nameof(Subjects)); }
        }
        public string MotherName
        {
            get => motherName;
            set { motherName = value; OnPropertyChanged(nameof(MotherName)); }
        }
        public string Address
        {
            get => address;
            set { address = value; OnPropertyChanged(nameof(Address)); }
        }
        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
