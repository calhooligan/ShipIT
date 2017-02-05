using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipIT.ViewModels;
using System.Windows.Input;

namespace ShipIT.Commands
{
    class AddShipmentCmd : ICommand
    {
        private ShipmentViewModel viewModel;
        public AddShipmentCmd(ShipmentViewModel _viewModel)
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
            viewModel.addShipment();
        }
    }
}
