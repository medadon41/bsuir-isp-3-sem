using _053505_Mazurenko_Lab9.Domain;
using System;
using System.Collections.Generic;

namespace _053505_Mazurenko_Lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Company> companies = new();
            var c1 = new Company { Name = "Haunted Family", Depart = new Depart { WorkFrom = DateTime.Now.AddHours(3), WorkTo = DateTime.Now.AddHours(11) } };
            companies.Add(c1);
            var c2 = new Company { Name = "Benzo Gang", Depart = new Depart { WorkFrom = DateTime.Now.AddHours(3), WorkTo = DateTime.Now.AddHours(13) } };
            companies.Add(c2);
            var c3 = new Company { Name = "Bandana", Depart = new Depart { WorkFrom = DateTime.Now.AddHours(3), WorkTo = DateTime.Now.AddHours(8) } };
            companies.Add(c3);
            var c4 = new Company { Name = "Haunted Benzo", Depart = new Depart { WorkFrom = DateTime.Now.AddHours(3), WorkTo = DateTime.Now.AddHours(24) } };
            companies.Add(c4);
            var c5 = new Company { Name = "Dirrt", Depart = new Depart { WorkFrom = DateTime.Now.AddHours(3), WorkTo = DateTime.Now.AddHours(5) } };
            companies.Add(c5);

            Serializer serializer = new();

            serializer.SerializeByLINQ(companies, "test3");

            var comp = serializer.DeSerializeByLINQ("test3");

            foreach(var item in comp)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
