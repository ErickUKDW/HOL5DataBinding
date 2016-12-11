using System;
using System.Collections.Generic;
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

using HOL5DataBinding.ViewModels;
using HOL5DataBinding.Models;
using System.ComponentModel;

namespace HOL5DataBinding
{
    /// <summary>
    /// Interaction logic for SampleDataProvider.xaml
    /// </summary>
    public partial class SampleDataProvider : Window
    {
        private PeopleSource myResources;
        public SampleDataProvider()
        {
            InitializeComponent();
            var objectDataProv = FindResource("src") as DataSourceProvider;
            myResources = objectDataProv.Data as PeopleSource;
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            //var objectDataProv = FindResource("src") as DataSourceProvider;
            //myResources = objectDataProv.Data as PeopleSource;
            //myResources = FindResource(this.Resources) as PeopleSource;
            MessageBox.Show(myResources.People[0].Name);
        }

        void SortHelper(string propertyName)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(myResources.People);
            if (view.SortDescriptions.Count > 0 && view.SortDescriptions[0].PropertyName == propertyName &&
                       view.SortDescriptions[0].Direction == ListSortDirection.Ascending)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(propertyName, ListSortDirection.Descending));
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(propertyName, ListSortDirection.Ascending));
            }
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            SortHelper("Name");
        }
    }
}
