using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Repair_Orders_App.Interfaces
{
   public interface IOrder
    {
        public bool IsRushOrder { get; set; }
        public bool IsNewCustomer { get; set; }

        public bool IsLargeOrder { get; set; }

        public OrderType OrderType { get; set; }
    }
    public enum OrderType
    {
        Repair,
        Hire
    }
        
}
