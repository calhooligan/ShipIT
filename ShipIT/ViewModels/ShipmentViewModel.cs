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
using ShipIT.Views;

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
            string jsonFile = GetJsonPath();
            StreamReader sr = new StreamReader(jsonFile);
            string json = sr.ReadToEnd();
            sr.Close();

            if (String.IsNullOrWhiteSpace(json))
            {
                shipments = new ObservableCollection<Shipment> { new Shipment() };
                //Write sample data to JSON
                Assembly assembly = Assembly.GetExecutingAssembly();
                StreamReader sReader = new StreamReader(assembly.GetManifestResourceStream("ShipIT.Data.Shipments.json"));
                string jsonData = sReader.ReadToEnd();
                sr.Close();

                //string newJson = JsonConvert.SerializeObject(jsonData);
                File.WriteAllText(jsonFile, jsonData);

                //============ Debug Use ==============
                //MessageBox.Show("")
                LoadShipmentData();
            }
            else
            {
                //Load data from JSON
                LoadShipmentData();
            }

            //Commands
            OpenCreateCommand = new OpenCreateCmd(this);
            OpenEditCommand = new OpenEditCmd(this);
            OpenUpdateStatusCommand = new OpenUpdateStatusCmd(this);
            RemoveCommand = new RemoveShipmentCmd(this);
            SaveCommand = new SaveShipmentsCmd(this);
            CancelCommand = new RelayCommand<Window>(this.CancelWindow);
        }
        #endregion

        #region Data Source Memebers
        //Load shipment data from local JSON
        public void LoadShipmentData()
        {
            string jsonFile = GetJsonPath();

            StreamReader sr = new StreamReader(jsonFile);
            var json = sr.ReadToEnd();
            sr.Close();

            shipments = JsonConvert.DeserializeObject<ObservableCollection<Shipment>>(json);
        }

        public string GetJsonPath()
        {
            //Determine directory for JSON storage
            string folderPath = System.Environment.
            GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            folderPath = System.IO.Path.Combine(folderPath, "Shipments");
            Directory.CreateDirectory(folderPath);

            //Return/create JSON file
            string filePath = System.IO.Path.Combine(folderPath, "shipments.json");
            if (File.Exists(filePath))
                return filePath;
            else
            {
                var file = File.Create(filePath);
                file.Close();
                return filePath;
            }
        }
        #endregion

        #region UI Interaction
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

        //Get most recently created shipment
        private Shipment newestShipment;
        public Shipment NewestShipment
        {
            get
            {
                return newestShipment;
            }
            set
            {
                if (value == shipments.Aggregate((x, y) => x.TrackingID > y.TrackingID ? x : y))
                    return;
                newestShipment = shipments.Aggregate((x, y) => x.TrackingID > y.TrackingID ? x : y);
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
        #endregion

        #region New Shipment Members
        public ICommand OpenCreateCommand
        {
            get;
            private set;
        }

        //Open "Create Shipment" window
        public void openCreateWindow()
        {
            addShipment();
            Create create = new Create();
            create.Show();
            //MessageBox.Show(newestShipment.ToString());
        }

        /*
        public ICommand AddCommand
        {
            get;
            private set;
        }*/

        // Add shipment to collection
        public void addShipment()
        {
            shipments.Add(new Shipment());
            newestShipment = shipments.Aggregate((x, y) => x.TrackingID > y.TrackingID ? x : y);
        }
        #endregion

        #region Edit Shipment Members
        public ICommand OpenEditCommand
        {
            get;
            private set;
        }

        public void openEditWindow()
        {
            Edit edit = new Edit();
            edit.Show();
        }
        #endregion

        #region Update Status Members
        public ICommand OpenUpdateStatusCommand
        {
            get;
            private set;
        }

        public void openUpdateStatusWindow()
        {
            UpdateStatus status = new UpdateStatus();
            status.Show();
        }
        #endregion

        #region Remove Shipment Members
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
        #endregion

        public void cancelShipment()
        {
            if (newestShipment != null)
            {
                var toCancel = newestShipment.ToString();
                shipments.Remove(newestShipment);
            }
        }

        public RelayCommand<Window> CancelCommand
        {
            get;
            private set;
        }

        private void CancelWindow(Window window)
        {
            cancelShipment();
            if (window != null)
            {
                window.Close();
            }
        }

        #region Save Data
        public ICommand SaveCommand
        {
            get;
            private set;
        }

        public void saveShipments()
        {
            string _jsonFile = GetJsonPath();
            string newJson = JsonConvert.SerializeObject(shipments);
            File.WriteAllText(_jsonFile, newJson);

            MessageBox.Show("Shipment Data Saved!");

            //====== Debug Use =========
            //MessageBox.Show(newJson);
        }
        #endregion

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
