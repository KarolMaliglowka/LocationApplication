using System;
using System.Collections.Generic;
using System.Text;

namespace LA.Core.Models
{
    public class Device
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Guid LocationId {get; set; }
        public Location location { get; set; }
    }
}
