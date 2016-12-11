using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HOL5DataBinding.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HOL5DataBinding.ViewModels
{
    public class PeopleSource : INotifyPropertyChanged
    {
        private ObservableCollection<Person> people;
        public ObservableCollection<Person> People
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
                OnPropertyChanged("People");
            }
        }
        public PeopleSource()
        {
            this.People = new ObservableCollection<Person>();
            People.Add(new Person { Name = "Jovan", Age = 5 });
            People.Add(new Person { Name = "Tonny", Age = 63 });
            People.Add(new Person { Name = "Jhonny", Age = 35 });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

