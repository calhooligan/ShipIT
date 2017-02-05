using Newtonsoft.Json;
using ShipIT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ShipIT.Commands;

namespace ShipIT.ViewModels
{
    class ShipmentViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Shipment> shipments;
        public ObservableCollection<Shipment> Shipments
        {
            get { return shipments; }
        }

        #region ViewModel Constructor
        public ShipmentViewModel()
        {
            //Read embedded JSON
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader sr = new StreamReader(assembly.GetManifestResourceStream("ShipIT.Data.Shipments.json"));
            string json = sr.ReadToEnd();
            sr.Close();

            if (String.IsNullOrWhiteSpace(json))
            {
                shipments = new ObservableCollection<Shipment> { new Shipment() };
            }
            else
            {
                LoadShipmentData();
            }

            //Commands
            AddCommand = new AddShipmentCmd(this);
            RemoveCommand = new RemoveShipmentCmd(this);
        }
        #endregion

        //Load shipment data from embedded JSON file
        public void LoadShipmentData()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader sr = new StreamReader(assembly.GetManifestResourceStream("ShipIT.Data.Shipments.json"));
            var json = sr.ReadToEnd();
            sr.Close();
            shipments = JsonConvert.DeserializeObject<ObservableCollection<Shipment>>(json);
        }

        //Tracks currently selected Employee object in listview/collection
        private Shipment selectedShipment;
        public Shipment SelectedShipment
        {
            get { return selectedShipment; }
            set
            {
                selectedShipment = value;
                OnPropertyChanged();
            }
        }

        // Controls button accessibility
        public bool CanUpdate
        {
            get
            {
                return true;
            }
        }

        public ICommand AddCommand
        {
            get;
            private set;
        }

        // Add shipmentto collection
        public void addShipment()
        {
            shipments.Add(new Shipment());
        }

        public ICommand RemoveCommand
        {
            get;
            private set;
        }

        // Removes employee at current location
        public void removeShipment()
        {
            if (selectedShipment != null)
            {
                var toRemove = selectedShipment.ToString();
                shipments.Remove(selectedShipment);
                MessageBox.Show("'" + toRemove + "'" + " has been removed.");
            }
            else
                MessageBox.Show("No item selected.");
        }

        /// <summary>
        /// CANNOT WRITE TO EMBEDDED SOURCE!!! Rethink JSON placement!!!
        /// </summary>
        /*public void saveShipmentData()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string jsonFile = assembly.GetFile("ShipIT.Data.Shipments.json");
            string newJson = JsonConvert.SerializeObject(shipments);
            File.WriteAllText(jsonFile, newJson);

            //MessageBox.Show("Shipment Data Saved!");

            //====== Debug Use =========
            //MessageBox.Show(newJson);
        }*/

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
