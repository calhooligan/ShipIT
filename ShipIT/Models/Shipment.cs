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

        /********************************************************************************
         *      TODO:
         *      Constructor for objects not created from JSON file must autofill:
         *          trackingID, status, and dateShipped
         * 
         * ******************************************************************************/

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

        private DateTime dateCreated;
        public DateTime DateCreated
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

        private Nullable<DateTime> dateDelivered;
        public Nullable<DateTime> DateDelivered
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
            return TrackingID + ", From: " + SenderName + ", To: " + DestinationName;
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
