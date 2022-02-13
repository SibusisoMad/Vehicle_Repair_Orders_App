using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Repair_Orders_App.Interfaces;

namespace Vehicle_Repair_Orders_App.Models
{
    public class Order : IOrder
    {
        public bool IsRushOrder { get ; set ; }
        public bool IsNewCustomer { get ; set ; }
        public bool IsLargeOrder { get ; set ; }
        public OrderType OrderType { get ; set ; }
    }
}
