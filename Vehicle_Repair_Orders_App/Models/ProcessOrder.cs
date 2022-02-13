using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Repair_Orders_App.Enums;
using Vehicle_Repair_Orders_App.Interfaces;

namespace Vehicle_Repair_Orders_App.Models
{
   public class ProcessOrder
    {
        private IOrder _order { get; set; }


        public ProcessOrder(IOrder order)
        {
            _order = order;
        }

        public ProcessOrder()
        {
            _order = new Order();
        }
        public ProcessOrder IsRushOrder (bool isRushOrder)
        {
            _order.IsRushOrder = isRushOrder;
            return this;
        }

        public ProcessOrder IsNewCustomer(bool isNewCustomer)
        {
            _order.IsNewCustomer = isNewCustomer;
            return this;
        }

        public ProcessOrder IsLargeOrder(bool isLargeOrder)
        {
            _order.IsLargeOrder = isLargeOrder;
            return this;
        }

        public ProcessOrder OrderType(OrderType orderType)
        {
            _order.OrderType = orderType;
            return this;
        }

        public OrderStatus OrderProcessing()
        {

            var status = this._order.IsNewCustomer &&  this._order.OrderType == Interfaces.OrderType.Repair && this._order.IsLargeOrder ? OrderStatus.Closed :
                this._order.IsRushOrder && this._order.OrderType == Interfaces.OrderType.Hire ? OrderStatus.Closed :
                this._order.IsLargeOrder && this._order.OrderType == Interfaces.OrderType.Repair ? OrderStatus.AuthorisationRequired :
                this._order.IsRushOrder && this._order.IsNewCustomer && this._order.IsLargeOrder == false ? OrderStatus.AuthorisationRequired :
                OrderStatus.Confirmed;
            Console.WriteLine($"{ status}");
            return status;
           
        }
    }
}
