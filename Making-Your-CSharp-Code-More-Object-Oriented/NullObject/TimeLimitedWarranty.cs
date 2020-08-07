using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class TimeLimitedWarranty : IWarranty
    {
        private DateTime DateIssued { get; }
        private TimeSpan Duration { get; }

        public TimeLimitedWarranty(DateTime dateIssued, TimeSpan duration)
        {
            this.DateIssued = dateIssued.Date;
            this.Duration = TimeSpan.FromDays(duration.Days);
        }

        public bool IsValidOn(DateTime date) => 
            date.Date >= this.DateIssued && date.Date < this.DateIssued + this.Duration;
    }
}
