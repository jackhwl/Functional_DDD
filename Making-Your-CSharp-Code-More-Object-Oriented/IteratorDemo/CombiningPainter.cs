using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class CombiningPainter : CompositePainter<ProportionalPainter>
    {
        private Func<double, IEnumerable<IPainter>, IEnumerable<Tuple<IPainter, double>>> ScheduleWork { get; }
        public CombiningPainter(IEnumerable<IPainter> painters,
            Func<double, IEnumerable<IPainter>, IEnumerable<Tuple<IPainter, double>>> scheduler) : base(painters)
        {
            base.Reduce = this.Combine;
            this.ScheduleWork = scheduler;
        }

        private IPainter Combine(double sqMeters, IEnumerable<IPainter> painters)
        {
            IEnumerable<IPainter> availablePainters = painters.Where(painter => painter.IsAvailable);

            IEnumerable<Tuple<IPainter, double>> schedule = this.ScheduleWork(sqMeters, availablePainters);

            TimeSpan time = schedule.Max(tuple => tuple.Item1.EstimateTimeToPaint(tuple.Item2));

            double cost = schedule.Sum(tuple => tuple.Item1.EstimateCompensation(tuple.Item2));

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }
    }
}
