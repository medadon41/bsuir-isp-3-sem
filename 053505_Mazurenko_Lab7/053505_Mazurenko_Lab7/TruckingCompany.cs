using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using _053505_Mazurenko_Lab7.Entites;

namespace _053505_Mazurenko_Lab7.Entities
{
    internal class TruckingCompany
    {
        public delegate void Change(string message, string info = "Awaken on collection's change");
        public delegate void GetOrder(string message, string info = "Awaken on order's create");

        public event Change OnChange;
        public event GetOrder OnOrder;

        private Dictionary<string, Rate> _rates;
        private List<User> _users;

        private int _uc = 0;

        public TruckingCompany()
        {
            _rates = new Dictionary<string, Rate>();
            _users = new List<User>();
        }

        public int UsersCount { get => _users.Count; }

        public void NextUser()
        {
            if (_uc + 1 > _users.Count)
                _uc = 0;
            _uc++;
        }

        public User CurrentUser { get => _users[_uc]; }

        public void Add(User user)
        {
            _users.Add(user);
            OnChange.Invoke($"User {user.Name} was added to the users list");
        }

        public void Add(Rate rate)
        {
            _rates.Add(rate.Name, rate);
            OnChange.Invoke($"Rate {rate.Name} was added to the rates list");
        }

        public void Remove(User user)
        {
            _users.Remove(user);
            OnChange.Invoke($"User {user.Name} was removed from the users list");
        }

        public void Remove(Rate rate)
        {
            _rates.Remove(rate.Name);
            OnChange.Invoke($"Rate {rate.Name} was removed from the rates list");
        }

        public void GenerateOrder(User user, Order ord, Rate rate)
        {
            user.CreateOrder(ord, rate);
            OnOrder.Invoke($"An order for user {user.Name} has been created. Picked rate: {rate.Name}");
        }

        public List<User> GetUsers() => _users;
        public Dictionary<string, Rate> GetRates() => _rates;
        
        //linq 
        public void GetSortedRates()
        {
            var SortedRatesList = (from r in _rates
                                   orderby r.Value.TpK descending
                                   select r.Value.Name);//.ToList();
            foreach (var r in SortedRatesList)
            {
                Console.WriteLine(r);
            }
        }

        public void GetTotalCost()
        {

            var sum = _users
                .Select(u => u.Orders.Sum(n => n.Cost))
                .Aggregate<double, double>(0, (current, ordSum) => current + ordSum);
            Console.Write(sum);
        }

        public void GetUserTotalCostByIndex(int i)
        {
            if (i >= _users.Count)
                return;

            Console.WriteLine(_users[i].Orders.Sum(n => n.Cost));
        }

        public void GetMaxPaidUser()
        {
            var MaxNameList = (from u in _users
                               orderby u.Orders.Sum(n => n.Cost) descending
                               select u.Name).First();
            Console.WriteLine(MaxNameList);
        }

        public void GetUsersPaidMore(double agg)
        {
            int num = (from u in _users
                       where u.Orders.Sum(n => n.Cost) > agg
                       select u).Count();

            
            Console.WriteLine(num);
        }
    }
}
