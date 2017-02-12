using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShipIT.Models
{
    public class Shipment : INotifyPropertyChanged
    {
        private static int counter = 3002;
       /********************************************************************************
        *      TODO:
        *      Constructor for objects not created from JSON file must autofill:
        *          trackingID, status, and dateShipped
        * 
        * ******************************************************************************/

        public Shipment()
        {
            this.TrackingID = System.Threading.Interlocked.Increment(ref counter);
            dateCreated = DateTime.Today.ToString();
        }

        public Shipment(string _senderName, string _senderDept, string _destinationName, string _destinationDept)
        {
            this.TrackingID = System.Threading.Interlocked.Increment(ref counter);
            dateCreated = DateTime.Today.ToString();
            status = "Ready for Pickup";
            senderName = _senderName;
            senderDept = _senderDept;
            destinationName = _destinationName;
            destinationDept = _destinationDept;
        }

        private int trackingID;
        public int TrackingID
        {
            get { return trackingID; }
            set
            {
                if ( value == trackingID )
                    return;
                trackingID = value;
                OnPropertyChanged();
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (value == status)
                    return;
                status = value;
                OnPropertyChanged();
            }
        }

        private string dateCreated;
        public string DateCreated
        {
            get { return dateCreated; }
            set
            {
                if (value == dateCreated)
                    return;
                dateCreated = value;
                OnPropertyChanged();
            }
        }

        private string dateDelivered;
        public string DateDelivered
        {
            get { return dateDelivered; }
            set
            {
                if (value == dateDelivered)
                    return;
                dateDelivered = value;
                OnPropertyChanged();
            }
        }

        private string destinationName;
        public string DestinationName
        {
            get { return destinationName; }
            set
            {
                if (value == destinationName)
                    return;
                destinationName = value;
                OnPropertyChanged();
            }
        }

        private string destinationDept;
        public string DestinationDept
        {
            get { return destinationDept; }
            set
            {
                if (value == destinationDept)
                    return;
                destinationDept = value;
                OnPropertyChanged();
            }
        }

        private string senderName;
        public string SenderName
        {
            get { return senderName; }
            set
            {
                if (value == senderName)
                    return;
                senderName = value;
                OnPropertyChanged();
            }
        }

        private string senderDept;
        public string SenderDept
        {
            get { return senderDept; }
            set
            {
                if (value == senderDept)
                    return;
                senderDept = value;
                OnPropertyChanged();
            }
        }

        #region Shipment ToString
        public override string ToString()
        {
            return "Shipment ID: " + TrackingID + ", From: " + SenderName + ", To: " + DestinationName;
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
