using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class PaintingGroup : IPainter
    {
        public bool IsAvailable => this.Painters.Any(painter => painter.IsAvailable);

        private IEnumerable<ProportionalPainter> Painters { get; }

        public PaintingGroup(IEnumerable<ProportionalPainter> painters)
        {
            this.Painters = painters.ToList();
        }

        private IPainter Reduce(double sqMeters)
        {
            TimeSpan time =
                TimeSpan.FromHours(
                           1 /
                           this.Painters
                            .Where(painter => painter.IsAvailable)
                            .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                            .Sum());

            double cost = this.Painters
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

        public TimeSpan EstimateTimeToPaint(double sqMeters) => this.Reduce(sqMeters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters) => this.Reduce(sqMeters).EstimateCompensation(sqMeters);
    }
}
