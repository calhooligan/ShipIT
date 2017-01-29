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

        //public string Item { get; set; } ?

        //public string ItemDescription { get; set; } ?

        public string OriginatorName { get; set; }

        public string OriginatorDept { get; set; }

        public string DestinationName { get; set; }

        public string DestinationDept { get; set; }

        #endregion
    }
}
