using __053505_Mazurenko_Lab8;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _053505_Mazurenko_Lab8
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string path = "file.txt";
            const string newPath = "newFile.txt";
            
            var fileService = new FileService();
            var employeeComparer = new EmployeeComparer();
            
            var employees1 = new List<Employee>();
            var employees2 = new List<Employee>
            {
                new("Nikita", 19, true),
                new("Marya", 18, true),
                new("Kirill", 18, false),
                new("Max", 65, true),
                new("Angel", 150, false),
            };

            try
            {
                // Write information in the file
                fileService.SaveData(employees2, path);
                // Rename file
                System.IO.File.Move(path, newPath);
                // Read information from the file
                employees1.AddRange(fileService.ReadFile(newPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var orderedEnumerable = employees1.OrderBy(x => x, employeeComparer);

            Console.WriteLine("______Start collection______");
            // print start collection
            foreach (var employee in employees2)
            {
                Console.WriteLine($"Name: {employee.Name}\n" +
                                  $"Age: {employee.Age}\n" +
                                  $"IsBelarus: {employee.IsBelarus}\n");
            }
            
            Console.WriteLine("______Sort collection______");
            // print sort collection
            foreach (var employee in orderedEnumerable)
            {
                Console.WriteLine($"Name: {employee.Name}\n" +
                                  $"Age: {employee.Age}\n" +
                                  $"IsBelarus: {employee.IsBelarus}\n");
            }
        }
    }
}