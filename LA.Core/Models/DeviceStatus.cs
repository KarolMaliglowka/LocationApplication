using System;
using System.Collections.Generic;
using System.Text;

namespace LA.Core.Models
{
    public class DeviceStatus
    {
        protected DeviceStatus()
        {
        }

        public DeviceStatus(Guid commentId, User author, string text)
        {
            //GuardExtensions.ThrowIfNull(author, nameof(author));
            //GuardExtensions.ThrowIfNull(commentId, nameof(commentId));
            //Id = commentId;
            //Author = author;
            //SetText(text);
            //CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public int BatteryChargeStatus { get; set; }
        public bool IsCharging { get; set; }
        public Guid deviceId { get; set; }
        public Device device { get; set; }
    }
}