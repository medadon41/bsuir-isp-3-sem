using _053505_Mazurenko_Lab7.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053505_Mazurenko_Lab7.Entites
{
    internal class User
    {
        public string Name;

        public DateTime RegDate;

        public List<Order> Orders;

        public User(string name)
        {
            Name = name;
            RegDate = DateTime.Now;
            Orders = new List<Order>();
        }

        public void CreateOrder(Order order, Rate rate)
        {
            order.PickedRate = rate;
            order.GenerateCost();

            Orders.Add(order);
        }
        public void GetOrdersInfo()
        {
            var ordersbyrates = from order in Orders
                                group order by order.PickedRate.Name;

            foreach(IGrouping<string, Order> ord in ordersbyrates)
            {
                Console.WriteLine(ord.Key);
                foreach (var o in ord)
                    Console.WriteLine(o.Cost);
                Console.WriteLine();
            }
        }
    }
}
