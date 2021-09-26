using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053505_Mazurenko_Lab7.Entites
{
    internal class Rate
    {
        public string Name;

        public double TpK;

        public double Perc;

        public Rate(string name, double tpk, int perc)
        {
            Name = name;
            TpK = tpk;
            Perc = (double)perc / (double)100;
        }
    }
}
