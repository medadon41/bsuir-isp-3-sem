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

            Thread t1 = new(() => sr.WriteToStreamTask(ms));
            Thread t2 = new(() => sr.CopyFromStreamTask(ms, "database.dat"));

            t1.Start();
            t2.Start();

            Console.WriteLine($"Cars with capacity over 2 litres - {await sr.GetStatisticsAsync("database.dat", countFunc)}");
        }
    }
}
