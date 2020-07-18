using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class CompositePainting<TPainter> : IPainter where TPainter : IPainter
    {
        public bool IsAvailable => this.Painters.Any(painter => painter.IsAvailable);

        private IEnumerable<TPainter> Painters { get; }

        private Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; }

        public CompositePainting(IEnumerable<TPainter> painters, Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            this.Painters = painters.ToList();
            this.Reduce = reduce;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters) => this.Reduce(sqMeters, this.Painters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters) => this.Reduce(sqMeters, this.Painters).EstimateCompensation(sqMeters);
    }
}
