using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using HOL5DataBinding.Models;

namespace HOL5DataBinding
{
    /// <summary>
    /// Interaction logic for SampleBinding1.xaml
    /// </summary>
    public partial class SampleBinding1 : Window
    {
        Person person;
        List<Person> lstPerson = new List<Person>();
        public SampleBinding1()
        {
            InitializeComponent();
            person = new Person { Name = "Squall Mystic", Age = 35.5 };
            lstPerson.Add(person);
            lstPerson.Add(new Person { Name = "Tonny", Age = 63 });
            lstPerson.Add(new Person { Name = "Jovan", Age = 5 });
            this.DataContext = lstPerson;
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            string message = person.Name + " - " + person.Age;
            MessageBox.Show("Data: " + message);
        }

        private void btnAge_Click(object sender, RoutedEventArgs e)
        {
            person.Age += 0.5;
        }
    }

    [ValueConversion(typeof(double),typeof(Brush))]
    public class AgeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double age;
            double.TryParse(value.ToString(), out age);
            return (age >= 30 ? Brushes.Red : Brushes.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
