using System;
using System.Collections.Generic;
using System.Text;

namespace LA.Core.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double PositionZ { get; set; }
        public DateTime CreateAt { get; set; }


    }
}
