using System.Windows;
using System.Windows.Controls;

namespace ShipIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Create createView;

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
    }
}
