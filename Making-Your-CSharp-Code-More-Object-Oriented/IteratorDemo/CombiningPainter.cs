using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class CombiningPainter : CompositePainter<ProportionalPainter>
    {
        public CombiningPainter(IEnumerable<ProportionalPainter> painters) : base(painters)
        {
            base.Reduce = this.Combine;
        }

        private IPainter Combine(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time = EstimateTime(sqMeters, painters);

            double cost = painters
                            .Where(painter => painter.IsAvailable)
                            .Select(painter =>
                                painter.EstimateCompensation(sqMeters) /
                                painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                            .Sum();

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }

        public Func<double, IEnumerable<IPainter>, TimeSpan> EstimateTime { get; set; }
        //private static TimeSpan EstimateTime(double sqMeters, IEnumerable<IPainter> painters)
        //{
        //    return TimeSpan.FromHours(
        //                                1 /
        //                                painters
        //                                .Where(painter => painter.IsAvailable)
        //                                .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
        //                                .Sum());
        //}
    }
}
