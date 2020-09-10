using System;
using System.Collections.Generic;
using System.Text;

namespace LA.Core.Models
{
    public class Localization
    {
        private IList<DeviceStatus> _deviceStatus = new List<DeviceStatus>();

        public IEnumerable<DeviceStatus> DeviceStatus => _deviceStatus;
    }
}
