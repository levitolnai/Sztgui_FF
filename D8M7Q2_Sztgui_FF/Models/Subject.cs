using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8M7Q2_Sztgui_FF.Models
{
    public class Subject: INotifyPropertyChanged
    {
        private string name;
        private int? firstSemester = null;
        private int? secondSemester = null;



        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }
        public int? FirstSemester
        {
            get => firstSemester;
            set { firstSemester = value; OnPropertyChanged(nameof(FirstSemester)); }
        }
        public int? SecondSemester
        {
            get => secondSemester;
            set { secondSemester = value; OnPropertyChanged(nameof(SecondSemester)); } 
        }
        public Subject(string name, int firstSemester, int secondSemester)
        {
            Name = name;
            FirstSemester = firstSemester;
            SecondSemester = secondSemester;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
