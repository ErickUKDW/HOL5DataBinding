using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HOL5DataBinding.Models
{
    public class Person : INotifyPropertyChanged,IDataErrorInfo
    {
        private string nameValue;
        
        [Required(ErrorMessage = "Nama harus diisi")]
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
        [Required(ErrorMessage = "Umur harus diisi")]
        [Range(30,60)]
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

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                if (Validator.TryValidateProperty(
                        GetType().GetProperty(columnName).GetValue(this)
                        , new ValidationContext(this)
                        {
                            MemberName = columnName
                        }
                        , validationResults))
                    return null;

                return validationResults.First().ErrorMessage;
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
