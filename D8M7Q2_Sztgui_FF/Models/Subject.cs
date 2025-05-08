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
        private int grade;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }
        public int Grade
        {
            get => grade;
            set { grade = value; OnPropertyChanged(nameof(Grade)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
