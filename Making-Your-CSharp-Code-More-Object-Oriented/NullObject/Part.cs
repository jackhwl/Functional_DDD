using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Part
    {
        public DateTime InstallmentDate { get; }
        public DateTime DefectDetectedOn { get; set; }

        public Part(DateTime installmentDate)
        {
            this.InstallmentDate = installmentDate;
        }

        public void MarkDefective(DateTime withDate)
        {
            this.DefectDetectedOn = withDate;
        }
    }
}
