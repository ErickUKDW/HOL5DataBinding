using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace HOL5DataBinding.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string nameValue;
        public string Name
        {
            get { return nameValue; }
            set {
                if(value!=nameValue)
                {
                    nameValue = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private double ageValue;
        public double Age
        {
            get { return ageValue; }
            set {
                if(value!=ageValue)
                {
                    ageValue = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
