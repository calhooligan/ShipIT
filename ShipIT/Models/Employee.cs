using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIT.Models
{
    class Employee
    {
        #region Employee Members

        public string EmployeeID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Department { get; set; }

        public ICollection<Shipment> Shipments { get; set; }

        #endregion
    }
}