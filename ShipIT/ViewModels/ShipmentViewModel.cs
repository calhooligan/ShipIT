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
            AddCommand = new AddShipmentCmd(this);
            RemoveCommand = new RemoveShipmentCmd(this);
            OpenCreateCommand = new OpenCreateCmd(this);
        }
        #endregion

        //Load shipment data from local JSON
        public void LoadShipmentData()
        {
            string jsonFile = GetJsonPath();

            StreamReader sr = new StreamReader(jsonFile);
            var json = sr.ReadToEnd();
            sr.Close();

            /*********************************************************************************************************
             *      
             *      TODO: Find way to have Shipment class detect object creation from JSON.Net so fields are not
             *              overwritten
             * 
             * *******************************************************************************************************/
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

        public ICommand OpenCreateCommand
        {
            get;
            private set;
        }

        //Open "Create Shipment" window
        public void openCreateWindow()
        {
            Create create = new Create();
            create.Show();
        }

        public ICommand AddCommand
        {
            get;
            private set;
        }

        // Add shipment to collection
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
