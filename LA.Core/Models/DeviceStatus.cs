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

        public DeviceStatus(Guid deviceId, int batteryChargeStatus, bool IsCharging)
        {
            Id = Guid.NewGuid();
            SetBatteryChargeStatus(batteryChargeStatus);
            //IsCharging = IsCharging;
            //deviceId = deviceId;
            CreateAt();
        }

        public Guid Id { get; set; }
        public int BatteryChargeStatus { get; set; }
        public bool IsCharging { get; set; }
        public Guid deviceId { get; set; }
        public Device device { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }


        private void SetBatteryChargeStatus(int batteryChargeStatus)
        {
            if (batteryChargeStatus < 0)
            {
                throw new ArgumentException(nameof(batteryChargeStatus), "Battery charge status show wrong value. Below 0%");
            }
            if (batteryChargeStatus > 100)
            {
                throw new ArgumentException(nameof(batteryChargeStatus), "Battery charge status show wrong value. More than 100%");
            }

            BatteryChargeStatus = batteryChargeStatus;
            UpdateAt();
        }


        private void UpdateAt() { UpdatedAt = DateTime.UtcNow; }
        private void CreateAt() { CreatedAt = DateTime.UtcNow; }


    }
}