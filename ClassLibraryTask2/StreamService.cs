using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibraryTask2
{
    public class StreamService
    {
        private object locker = new();
        public void WriteToStream(Stream stream)
        {

            lock (locker)
            {
                Console.WriteLine($"Writing to stream...[{Thread.CurrentThread.ManagedThreadId}]");
                Random rnd = new();
                StreamWriter sw = new(stream) { AutoFlush = true };

                for (int i = 0; i < 100; i++)
                {
                    sw.WriteLine(i);
                    sw.WriteLine($"Car #{i}");
                    sw.WriteLine(rnd.Next(0, 7));
                }
                Console.WriteLine($"Writing to stream ended [{Thread.CurrentThread.ManagedThreadId}]");
            }
        }

        public void CopyFromStream(Stream stream, string filename)
        {

            lock (locker)
            {
                Console.WriteLine($"Copying from stream... [{Thread.CurrentThread.ManagedThreadId}]");
                stream.Seek(0, SeekOrigin.Begin);
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                using var fs = File.Open(filename, FileMode.OpenOrCreate);
                stream.CopyTo(fs);
                Console.WriteLine($"Copying from stream ended [{Thread.CurrentThread.ManagedThreadId}]");
            }
        }

        public int GetStatistics(string filename, Func<Car, bool> filter)
        {
            lock (locker)
            {
                Console.WriteLine($"Calculating stats... [{Thread.CurrentThread.ManagedThreadId}]");
                StreamReader sr = new(File.Open(filename, FileMode.Open));
                int count = 0;
                List<Car> cars = new();
                for (int i = 0; i < 100; i++)
                {
                    var car = new Car
                    {
                        Id = Convert.ToInt32(sr.ReadLine()),
                        Model = sr.ReadLine(),
                        EngineCapacity = Convert.ToInt32(sr.ReadLine())
                    };
                    cars.Add(car);

                    if (filter(cars[i]))
                    {
                        count++;
                    }
                }
                sr.Dispose();
                Console.WriteLine($"Calculating stats ended [{Thread.CurrentThread.ManagedThreadId}]");
                return count;
            }
        }

        public Task WriteToStreamTask(Stream stream) =>
            Task.Run(() => WriteToStream(stream));

        public Task CopyFromStreamTask(Stream stream, string filename) =>
            Task.Run(() => CopyFromStream(stream, filename));

        public async Task<int> GetStatisticsAsync(string filename, Func<Car, bool> filter) =>
            await Task.Run(() => GetStatistics(filename, filter));
    }
}
