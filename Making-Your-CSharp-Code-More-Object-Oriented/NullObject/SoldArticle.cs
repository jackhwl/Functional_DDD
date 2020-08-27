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

        private bool IsOperational { get; set; }
        private bool IsCircuitryOperational { get; set; }
        private bool IsVisiblyDamaged { get; set; }


        public SoldArticle(IWarranty moneyBack, IWarranty express, IWarrantyMapFactory rulesFactory)
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
            this.WarrantyMap = rulesFactory.Create(this.ClaimMoneyBack, this.ClaimNotOperationalWarranty, this.ClaimCircuitryWarranty);
        }

        private void ClaimMoneyBack(Action action)
        {
            this.MoneyBackGuarantee.Claim(DateTime.Now, action);
        }
        private void ClaimNotOperationalWarranty(Action action)
        {
            this.NotOperationalWarranty.Claim(DateTime.Now, action);
        }
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
            //this.WarrantyMap[this.OperationalStatus].Invoke(onValidClaim);

            bool moneyReturned = false;
            bool isAroundChristmas = this.IsAroundChristmas();
            if (isAroundChristmas)
            {
                this.MoneyBackGuarantee.Claim(DateTime.Now, () =>
                {
                    moneyReturned = true;
                    onValidClaim();
                });
            }

            if (!moneyReturned && !this.IsOperational)
                this.NotOperationalWarranty.Claim(DateTime.Now, onValidClaim);
            else if(!moneyReturned &&  !this.IsCircuitryOperational)
                this.Circuitry
                    .WhenSome()
                    .Do(c => this.CircuitryWarranty.Claim(c.DefectDetectedOn, onValidClaim))
                    .Execute();
            else if (!isAroundChristmas && !this.IsVisiblyDamaged)
                this.MoneyBackGuarantee.Claim(DateTime.Now, onValidClaim);
        }

        private bool IsAroundChristmas() => false;
    }
}
