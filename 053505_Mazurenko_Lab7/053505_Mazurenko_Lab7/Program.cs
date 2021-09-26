using _053505_Mazurenko_Lab7.Entites;
using _053505_Mazurenko_Lab7.Entities;
using System;
using System.Linq;

namespace _053505_Mazurenko_Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TruckingCompany Company1 = new TruckingCompany();

            Company1.OnChange += (message, info) => { Console.WriteLine(message); };

            Journal events = new Journal();

            Company1.OnOrder += events.DisplayMessage;

            User u1 = new User("Danila");
            Order ord1u1 = new Order(0.067, 0.75, 320);
            Rate r1 = new Rate("R20", 2, 20);
            Company1.Add(u1);
            Company1.Add(r1);
            Company1.GenerateOrder(u1, ord1u1, r1);

            Order ord2u1 = new Order(0.124, 1.25, 120);
            Company1.GenerateOrder(u1, ord2u1, r1);

            Order ord3u1 = new Order(0.500, 1, 200);
            Company1.GenerateOrder(u1, ord3u1, r1);

            User u2 = new User("Nikita");
            Rate r2 = new Rate("R10", 4, 10);
            Company1.Add(r2);
            Company1.Add(u2);

            Order ord1u2 = new Order(1, 1, 110);
            Company1.GenerateOrder(u2, ord1u2, r2);

            Order ord2u2 = new Order(0.001, 2, 123);
            Company1.GenerateOrder(u2, ord2u2, r1);

            User u3 = new User("Misha");
            Order ord1u3 = new Order(2.5, 0.45, 210);

            Company1.Add(u3);
            Company1.GenerateOrder(u3, ord2u2, r1);

            var Users = Company1.GetUsers();
            var Rates = Company1.GetRates();

            //---------1------------
            Console.WriteLine("\nRates available: ");
            Company1.GetSortedRates();
            //---------2------------
            Console.Write("\nTotal cost of all orders done: ");
            Company1.GetTotalCost();
            //---------3------------
            Console.Write("\nTotal cost of the first user's orders: ");
            Company1.GetUserTotalCostByIndex(0);
            //---------4------------
            Console.Write("\nThe user who paid the most: ");
            Company1.GetMaxPaidUser();
            //---------5------------
            Console.WriteLine("\nNumber of users who paid more than 200 BYN: ");
            Company1.GetUsersPaidMore(200);
            //---------6------------
            Console.WriteLine("\nList of the first user's spents for each rate:");
            Users[1].GetOrdersInfo();
        }
    }
}
