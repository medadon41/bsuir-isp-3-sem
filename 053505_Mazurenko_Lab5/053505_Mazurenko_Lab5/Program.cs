using System;
using _053505_Mazurenko_Lab5.Collections;
using _053505_Mazurenko_Lab5.Entities;

namespace _053505_Mazurenko_Lab5
{
    class Program
    {
        static void ShowUsers(MyCustomCollection<User> users)
        {
            Item<User> current = users.Head;
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"\n------{i}------");
                Console.WriteLine($"Name: {current.data.Name}\nOrder Volume: {current.data.OrderVol} m^3\nOrder Weight: {current.data.OrderWeight} tonn\nOrder Distantion: {current.data.OrderDist} km");
                if(current.data.PickedRate != null)
                {
                    Console.WriteLine($"Picked Rate: {current.data.PickedRate.Name}");
                    current.data.GenerateCost();
                    Console.WriteLine($"Total cost: {current.data.Cost} BYN");
                }
                current = current.Next;
            }
        }

        static double TotalCost(MyCustomCollection<User> users)
        {
            double totalcost = 0;
            Item<User> current = users.Head;
            while(current.Next != null)
            {
                if (current.data.PickedRate != null)
                {
                    totalcost += current.data.Cost;
                    Console.WriteLine("AAAAAAAAAAAa");
                }

                current = current.Next;
            }

            return totalcost;
        }
        static void Main(string[] args)
        {
            MyCustomCollection<User> Users = new MyCustomCollection<User>();

            User u1 = new User("aye basota", 0.067, 0.75, 320);

            Rate r1 = new Rate("kaloperevozka", 2, 20);

            u1.PickedRate = r1;

            u1.GenerateCost();

            Users.Add(u1);

            User u2 = new User("kal", 1, 1, 110);

            u2.PickedRate = r1;

            u2.GenerateCost();

            Users.Add(u2);

            User u3 = new User("ssaki", 2.5, 0.45, 210);

            User u4 = new User("ssaki", 2.5, 0.45, 210);

            Users.Add(u3);

            Console.WriteLine(Users.Count);

            ShowUsers(Users);

            Users.Next();
            Console.WriteLine(Users.Current().Name);
            Users.RemoveCurrent();

            ShowUsers(Users);

            Users.Remove(u4);

            Console.WriteLine($"\nTotal cost of all orders: {TotalCost(Users)}");

            Console.WriteLine($"\nCost for the first user: {Users[0].Cost}");
        }
    }
}
