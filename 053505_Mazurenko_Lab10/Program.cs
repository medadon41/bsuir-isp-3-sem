using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

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

            Assembly asm = Assembly.LoadFrom("ClassLibrary.dll");
            Type t = asm.GetType("ClassLibrary.FileService`1", true, true).MakeGenericType(typeof(Employee));
            object obj = Activator.CreateInstance(t);

            MethodInfo method1 = t.GetMethod("SaveData");
            MethodInfo method2 = t.GetMethod("ReadFile");
            try
            {
                method1.Invoke(obj, new object[] { employees1, path});
                var result = await (Task<IEnumerable<Employee>>)method2.Invoke(obj, new object[] { path });
                employees2.AddRange(result);
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
