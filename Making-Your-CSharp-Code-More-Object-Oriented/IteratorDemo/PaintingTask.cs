using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class PaintingTask<TPainter> where TPainter : IPainter
    {
        public TPainter Painter { get; }
        public double SquareMeters { get; }

        public PaintingTask(TPainter painter, double sqMeters)
        {
            this.Painter = painter;
            this.SquareMeters = sqMeters;
        }
    }
}
