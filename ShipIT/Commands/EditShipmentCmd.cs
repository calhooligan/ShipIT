using ShipIT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShipIT.Commands
{
    class EditShipmentCmd : ICommand
    {
        private ShipmentViewModel viewModel;
        public EditShipmentCmd(ShipmentViewModel _viewModel)
        {
            this.viewModel = _viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return viewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            //viewModel.editShipment();
        }
    }
}
