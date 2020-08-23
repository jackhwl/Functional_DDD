using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class DeviceStatus
    {
        [Flags]
        private enum StatusRepresentation
        {
            AllFine = 0,
            NotOperational = 1,
            VisiblyDamaged = 2,
            CircuitryFailed = 4
        }

        private StatusRepresentation Representation { get;}

        private DeviceStatus(StatusRepresentation representation)
        {
            this.Representation = representation;
        }

        public static DeviceStatus AllFine() => new DeviceStatus(StatusRepresentation.AllFine);
        public DeviceStatus WithVisibleDamage() => new DeviceStatus(this.Representation | StatusRepresentation.VisiblyDamaged);
        public DeviceStatus NotOperational() => new DeviceStatus(this.Representation | StatusRepresentation.NotOperational);
        public DeviceStatus Repaired() => new DeviceStatus(this.Representation & ~StatusRepresentation.NotOperational);
        public DeviceStatus CircuitryFailed() => new DeviceStatus(this.Representation | StatusRepresentation.CircuitryFailed);
        public DeviceStatus CircuitryReplaced() => new DeviceStatus(this.Representation & ~StatusRepresentation.CircuitryFailed);
    }
}
