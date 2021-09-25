using System;
using _053505_Mazurenko_Lab5.Collections;
using _053505_Mazurenko_Lab5.Entities;

namespace _053505_Mazurenko_Lab5
{
    class Program
    {
        
        static void Main(string[] args)
        {
            TruckingCompany Company1 = new TruckingCompany();

            Company1.OnChange += (message, info) => { Console.WriteLine(message); };

            Journal events = new Journal();

            Company1.OnOrder += events.DisplayMessage;

            User u1 = new User("Danila", 0.067, 0.75, 320);

            Rate r1 = new Rate("R20", 2, 20);

            Company1.Add(u1);

            Company1.CreateOrder(u1, r1);

            User u2 = new User("Nikita", 1, 1, 110);

            Company1.Add(u2);

            Company1.CreateOrder(u2, r1);

            User u3 = new User("Misha", 2.5, 0.45, 210);

            User u4 = new User("Daniil", 2.5, 0.45, 210);

            Company1.Add(u3);

            Console.WriteLine(Company1.UsersCount);

            Company1.ShowUsers();

            Company1.NextUser();
            Console.WriteLine(Company1.CurrentUser.Name);
           // Company1.Users.RemoveCurrent();

            Company1.ShowUsers();

            Company1.Remove(u3);

            Console.WriteLine($"\nTotal cost of all orders: {Company1.TotalCost()}");
        }
    }
}
