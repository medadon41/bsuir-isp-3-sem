using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Mazurenko_Lab5.Collections;

namespace _053505_Mazurenko_Lab5.Entities
{
    class TruckingCompany
    {
        public TruckingCompany()
        {
            _users = new MyCustomCollection<User>();
            _rates = new MyCustomCollection<Rate>();
        }

        public delegate void Change(string message, string info = "Awaken on collection's change");
        public delegate void Order(string message, string info = "Awaken on order's create");

        public event Change OnChange;
        public event Order OnOrder;

        private MyCustomCollection<User> _users;

        private MyCustomCollection<Rate> _rates;

        public int UsersCount  { get => _users.Count; } 

        public void UsersNext() => _users.Next();

        public User CurrentUser { get => _users.Current(); }

        public void NextUser() => _users.Next();
        public void Add(User user)
        {
            _users.Add(user);
            OnChange?.Invoke($"User {user.Name} was added to the users list");
        }

        public void Add(Rate rate)
        {
            _rates.Add(rate);
            OnChange?.Invoke($"Rate {rate.Name} was added to the rates list");
        }

        public void Remove(User user)
        {
            _users.Remove(user);
            OnChange.Invoke($"User {user.Name} was removed from the users list");
        }

        public void Remove(Rate rate)
        {
            _rates.Remove(rate);
            OnChange.Invoke($"Rate {rate.Name} was removed from the rates list");
        }

        public void CreateOrder(User user, Rate rate)
        {
            user.PickedRate = rate;
            user.GenerateCost();
            OnOrder.Invoke($"An order for user {user.Name} has been created. Picked rate: {rate.Name}");
        }

        public void ShowUsers()
        {
            Item<User> current = _users.Head;
            for (int i = 0; i < _users.Count; i++)
            {
                Console.WriteLine($"\n------{i}------");
                Console.WriteLine($"Name: {current.data.Name}\nOrder Volume: {current.data.OrderVol} m^3\nOrder Weight: {current.data.OrderWeight} tonn\nOrder Distantion: {current.data.OrderDist} km");
                if (current.data.PickedRate != null)
                {
                    Console.WriteLine($"Picked Rate: {current.data.PickedRate.Name}");
                    current.data.GenerateCost();
                    Console.WriteLine($"Total cost: {current.data.Cost} BYN");
                }
                current = current.Next;
            }
        }
        
        public double TotalCost()
        {
            double totalcost = 0;
            Item<User> current = _users.Head;
            while (current != null)
            {
                if (current.data.PickedRate != null)
                {
                    totalcost += current.data.Cost;
                }

                current = current.Next;
            }

            return totalcost;
        }
    }
}
