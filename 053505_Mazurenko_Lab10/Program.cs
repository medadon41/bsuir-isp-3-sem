using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary;

namespace _053505_Mazurenko_Lab10
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string path = "file.json";
            var employees1 = new List<Employee>
            {
                new ("Oleg", 31, false),
                new ("Egor", 21, true),
                new ("Andrey", 20, false),
                new ("Danila", 18, true),
                new ("Nikita", 29, true)
            };
            var employees2 = new List<Employee>();
            var fileService = new FileService<Employee>();

            try
            {
                fileService.SaveData(employees1, path);
                employees2.AddRange(await fileService.ReadFile(path));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var employee in employees2)
                Console.WriteLine($"Name: {employee.Name}\nAge: {employee.Age}\nIsInIt: {employee.IsIt}\n");
        }
    }
}
