using _053505_Mazurenko_Lab7.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053505_Mazurenko_Lab7.Entities
{
    internal class Order
    {
        public double OrderVol;

        public double OrderWeight;

        public int OrderDist;

        public Rate PickedRate;

        public double Cost;

        public Order(double weight, double vol, int dist)
        {
            OrderWeight = weight;
            OrderVol = vol;
            OrderDist = dist;
        }
        public void GenerateCost()
        {
            double cost;
            double factvol = (OrderWeight * 1000) / OrderVol;

            if (factvol > 250)
            {
                cost = OrderWeight * PickedRate.TpK * OrderDist;
            }
            else
            {
                double volwieght = OrderVol * 250;
                cost = (volwieght / 1000) * PickedRate.TpK * OrderDist;
            }

            Cost = cost + cost * PickedRate.Perc;
        }

    }
}
