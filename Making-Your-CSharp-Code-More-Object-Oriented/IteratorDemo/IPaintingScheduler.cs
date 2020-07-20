using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    interface IPaintingScheduler<TPainter> where TPainter : IPainter
    {
        IEnumerable<PaintingTask<TPainter>> Schedule(double sqMeters, IEnumerable<TPainter> painters);
    }
}
