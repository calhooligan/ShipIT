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
using ShipIT.Views;

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

        //Highlights listview item when selected
        void Item_GotFocus(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            this.lvShipments.SelectedItem = item.DataContext;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Create create = new Create();
            create.Show();
        }
    }
}
