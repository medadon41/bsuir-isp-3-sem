using System;
using System.Diagnostics;
using System.Threading;

namespace ClassLibraryTask1
{
    public static class Sinus
    {
        public delegate void OutputFunction(double result);
        public static event OutputFunction onFinishCalc;

        public static void Integral(object obj)
        {
            Console.WriteLine(Thread.CurrentThread.ThreadState);
            Stopwatch sw = new();
            sw.Start();
            SinusParams sp = (SinusParams)obj;
            double result = 0, h = (sp.b - sp.a) / sp.n;

            for (int i = 0; i < sp.n; i++)
            {
                result += Math.Sin(sp.a + h * (i + 0.5));
            }

            result *= h;
            sw.Stop();
            onFinishCalc(result);
            Console.WriteLine(sw.Elapsed);
        }
    }

    public static class Handler
    {
        public static void Message(double result)
        {
            Console.WriteLine(result);
        }
    }
}
