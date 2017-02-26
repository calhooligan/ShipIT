using System.Windows;
using System.Windows.Controls;

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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            txtBxDestName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxDestDept.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxSenderName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxSenderDept.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxNotes.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            CreateWindow.Close();
        }
    }
}
