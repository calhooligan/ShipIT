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

namespace ShipIT.Views
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            txtBxDestName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxDestDept.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxSenderName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxSenderDept.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            CreateWindow.Close();
        }
    }
}
