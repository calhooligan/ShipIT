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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace ShipIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Item_GotFocus(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            this.lvShipments.SelectedItem = item.DataContext;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource sHIPMENTViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sHIPMENTViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // sHIPMENTViewSource.Source = [generic data source]
        }
    }
}
