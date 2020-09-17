using System;
using System.Collections.Generic;
using System.Text;

namespace LA.Core.Models
{
    public class Additional
    {
        public Guid Id { get; set; }
        public int BatteryStatus { get; set; }
        public bool ChargingBattery { get; set; }
    }
}
