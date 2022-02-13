using System;
using Vehicle_Repair_Orders_App.Interfaces;
using Vehicle_Repair_Orders_App.Models;

namespace Vehicle_Repair_Orders_App
{
    public class Program
    {
       public static void Main(string[] args)
        {
            ProcessOrder orderItem = new ProcessOrder();

            orderItem.IsNewCustomer(true);
            orderItem.IsRushOrder(true);
            orderItem.OrderType(OrderType.Hire);
            orderItem.IsLargeOrder(false);
            
            

            orderItem.OrderProcessing();
            Console.Read();
        }
    }
}
