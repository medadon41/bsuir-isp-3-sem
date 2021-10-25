using ClassLibraryTask1;
using System;
using System.Threading;

namespace _053505_Mazurenko_Lab11_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sinus.onFinishCalc += Handler.Message;
            SinusParams sp = new SinusParams(0, 1, 100000000);
            Thread t1 = new(Sinus.Integral);
            Thread t2 = new(new ParameterizedThreadStart(Sinus.Integral));
            t1.Priority = ThreadPriority.Lowest;
            t2.Priority = ThreadPriority.Highest;

            t1.Start(sp);
            t2.Start(sp);
        }
    }
}
