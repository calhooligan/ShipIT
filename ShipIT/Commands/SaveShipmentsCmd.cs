using ShipIT.ViewModels;
using System;
using System.Windows.Input;

namespace ShipIT.Commands
{
    class SaveShipmentsCmd : ICommand
    {
        private ShipmentViewModel viewModel;
        public SaveShipmentsCmd(ShipmentViewModel _viewModel)
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
            viewModel.saveShipments();
        }
    }
}
