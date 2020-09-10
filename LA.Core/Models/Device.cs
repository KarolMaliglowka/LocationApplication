using System;
using System.Collections.Generic;
using System.Text;

namespace LA.Core.Models
{
    public class Device
    {

       //private IList<Localization> _localization = new List<Localization>();


        public Guid Id { get; set; }
        public string Name { get; set; }

        //public IEnumerable<Localization> Localization => _localization;
        public DeviceStatus deviceStatus { get; set; }
    }
}
