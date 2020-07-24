using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class Program
    {
        private static IPainter FindCheapestPainterBad(double sqMeters, IEnumerable<IPainter> painters)
        {
            double bestPrice = 0;
            IPainter cheapest = null;

            foreach (IPainter painter in painters)
            {
                if (painter.IsAvailable)
                {
                    double price = painter.EstimateCompensation(sqMeters);
                    if (cheapest == null || price < bestPrice)
                    {
                        cheapest = painter;
                    }
                }
            }

            return cheapest;
        }

        //private static IPainter FindCheapestPainter(double sqMeters, Painters painters) =>
        //    painters.GetAvailable().GetCheapestOne(sqMeters);

        //private static IPainter FindFastestPainter(double sqMeters, Painters painters) =>
        //    painters.GetAvailable().GetFastestOne(sqMeters);

        static void Main(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new ProportionalPainter[10];

            IPainter painter = CompositePainterFactories.CombineProportional(painters);
        }
    }
}
