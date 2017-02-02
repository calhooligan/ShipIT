using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIT.Models
{
    class Shipment //: IDataErrorInfo
    {
        #region Shipment Members

        public int TrackingNum { get; set; }

        public DateTime DateShipped { get; set; }

        public Employee Shipper { get; set;  }

        public Employee Receiver { get; set; }

        #endregion
    }
}
