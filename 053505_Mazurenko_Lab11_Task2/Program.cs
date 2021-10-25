using ClassLibraryTask2;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _053505_Mazurenko_Lab11_Task2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Func<Car, bool> countFunc = Car.GetIsBigger;
            MemoryStream ms = new();
            StreamService sr = new();

            var t1= sr.WriteToStreamTask(ms);
            var t2 = sr.CopyFromStreamTask(ms, "database.dat");

            await Task.WhenAll(new Task[] { t1, t2 });

            Console.WriteLine($"Cars with capacity over 2 litres - {await sr.GetStatisticsAsync("database.dat", countFunc)}");
            Console.ReadLine();
        }
    }
}
