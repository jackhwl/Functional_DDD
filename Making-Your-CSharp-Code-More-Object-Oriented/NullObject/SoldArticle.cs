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
        private IReadOnlyDictionary<DeviceStatus, Action<Action>> WarrantyMap { get; }


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

            this.OperationalStatus = DeviceStatus.AllFine();
            this.WarrantyMap = this.InitializeWarrantyMap();
        }

        private IReadOnlyDictionary<DeviceStatus, Action<Action>> InitializeWarrantyMap() =>
            new Dictionary<DeviceStatus, Action<Action>>()
            {
                [DeviceStatus.AllFine()] = this.ClaimMoneyBack,
                [DeviceStatus.AllFine().NotOperational()] = this.ClaimNotOperationalWarranty,
                [DeviceStatus.AllFine().WithVisibleDamage()] = (action) => { },
                [DeviceStatus.AllFine().NotOperational().WithVisibleDamage()] = this.ClaimNotOperationalWarranty,
                [DeviceStatus.AllFine().CircuitryFailed()] = this.ClaimCircuitryWarranty,
                [DeviceStatus.AllFine().NotOperational().CircuitryFailed()] = this.ClaimNotOperationalWarranty,
                [DeviceStatus.AllFine().CircuitryFailed().WithVisibleDamage()] = this.ClaimCircuitryWarranty,
                [DeviceStatus.AllFine().WithVisibleDamage()] = (action) => { },
                [DeviceStatus.AllFine().NotOperational().WithVisibleDamage().CircuitryFailed()] = this.ClaimNotOperationalWarranty
            };
        public void VisibleDamage()
        {
            this.OperationalStatus = this.OperationalStatus.WithVisibleDamage();
        }

        public void NotOperational()
        {
            this.OperationalStatus = this.OperationalStatus.NotOperational();
        }

        public void Repaired()
        {
            this.OperationalStatus = this.OperationalStatus.Repaired();
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
            this.OperationalStatus = this.OperationalStatus.CircuitryReplaced();
        }

        public void ClaimCircuitryWarranty(Action onValidClaim)
        {
            this.Circuitry.Do(circuitry => 
                this.CircuitryWarranty.Claim(circuitry.DefectDetectedOn, onValidClaim));
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            this.WarrantyMap[this.OperationalStatus].Invoke(onValidClaim);
        }
    }
}
