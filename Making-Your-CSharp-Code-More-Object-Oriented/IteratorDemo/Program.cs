﻿using System;
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

        private static IPainter FindCheapestPainter(double sqMeters, Painters painters) =>
            painters.GetAvailable().GetCheapestOne(sqMeters);

        private static IPainter FindFastestPainter(double sqMeters, Painters painters) =>
            painters.GetAvailable().GetFastestOne(sqMeters);

        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters) 
        {
            TimeSpan time = 
                TimeSpan.FromHours(
                           1 / 
                           painters
                            .Where(painter => painter.IsAvailable)
                            .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                            .Sum());

            double cost = painters
                            .Where(painter => painter.IsAvailable)
                            .Select(painter => 
                                painter.EstimateCompensation(sqMeters) / 
                                painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                            .Sum();

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours/sqMeters),
                DollarsPerHour = cost/time.TotalHours
            };
        }

        static void Main(string[] args)
        {
        }
    }
}