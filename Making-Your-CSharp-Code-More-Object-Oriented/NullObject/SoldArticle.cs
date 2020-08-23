using NullObject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class SoldArticle
    {
        public IWarranty MoneyBackGuarantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }

        public IWarranty NotOperationalWarranty { get; }
        
        private Option<Part> Circuitry { get; set; } = Option<Part>.None();

        private DeviceStatus OperationalStatus { get; set; }

        private IWarranty FailedCircuitryWarranty { get; set; }
        private IWarranty CircuitryWarranty { get; set; }

        public SoldArticle(IWarranty moneyBack, IWarranty express)
        {
            if (moneyBack == null)
                throw new ArgumentNullException(nameof(moneyBack));
            if (express == null)
                throw new ArgumentNullException(nameof(express));

            this.MoneyBackGuarantee = moneyBack;
            this.ExpressWarranty = VoidWarranty.Instance;
            this.NotOperationalWarranty = express;
            this.CircuitryWarranty = VoidWarranty.Instance;
        }

        public void VisibleDamage()
        {
            this.OperationalStatus |= DeviceStatus.VisiblyDamaged;
        }

        public void NotOperational()
        {
            this.OperationalStatus |= DeviceStatus.NotOperational;
        }

        public void Repaired()
        {
            this.OperationalStatus &= ~DeviceStatus.NotOperational;
        }

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            this.Circuitry.Do(circuitry => { 
                circuitry.MarkDefective(detectedOn);
                this.CircuitryWarranty = this.FailedCircuitryWarranty;
            });
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            this.Circuitry = Option<Part>.Some(circuitry);
            this.FailedCircuitryWarranty = extendedWarranty;
        }

        public void ClaimCircuitryWarranty(Action onValidClaim)
        {
            this.Circuitry.Do(circuitry => 
                this.CircuitryWarranty.Claim(circuitry.DefectDetectedOn, onValidClaim));
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            switch (this.OperationalStatus)
            {
                case DeviceStatus.AllFine:
                    this.MoneyBackGuarantee.Claim(DateTime.Now, onValidClaim);
                    break;
                case DeviceStatus.NotOperational:
                case DeviceStatus.NotOperational | DeviceStatus.VisiblyDamaged:
                case DeviceStatus.NotOperational | DeviceStatus.CircuitryFailed:
                case DeviceStatus.NotOperational | DeviceStatus.VisiblyDamaged | DeviceStatus.CircuitryFailed:
                    this.NotOperationalWarranty.Claim(DateTime.Now, onValidClaim);
                    break;
                case DeviceStatus.VisiblyDamaged:
                    break;
                case DeviceStatus.CircuitryFailed:
                case DeviceStatus.VisiblyDamaged | DeviceStatus.CircuitryFailed:
                    this.Circuitry
                        .WhenSome()
                        .Do(c => this.CircuitryWarranty.Claim(c.DefectDetectedOn, onValidClaim))
                        .Execute();
                    break;
            }
        }
    }
}
