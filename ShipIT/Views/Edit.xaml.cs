using System.Windows;
using System.Windows.Controls;

namespace ShipIT.Views
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditSubmit_Click(object sender, RoutedEventArgs e)
        {
            txtBxEditDestName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxEditDestDept.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxSEditSenderName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtEditBxSenderDept.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBxEditNotes.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            EditWindow.Close();
        }
    }
}
