using System;

namespace LA.Core.Models
{
    public class Location
    {
        protected Location()
        {
        }

        public Location(Device device, double? positionX, double? positionY, double? positionZ, int batteryChargeStatus, bool isCharging)
        {
            Id = Guid.NewGuid();
            SetDevice(device);
            SetPositionX(positionX);
            SetPositionY(positionY);
            SetPositionZ(positionZ);
            SetBatteryChargeStatus(batteryChargeStatus);
            SetIsCharging(isCharging);
            CreateAt();
        }
        
        public Guid Id { get; set; }
        public double? PositionX { get; private set; }
        public double? PositionY { get; private set; }
        public double? PositionZ { get; private set; }
        public int BatteryChargeStatus { get; private set; }
        public bool IsCharging { get; private set; }
        public Device Device { get; private set; }
        public Guid DeviceId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private void SetPositionX(double? positionX)
        {
            PositionX = positionX;
            UpdateAt();
        }
        private void SetPositionY(double? positionY)
        {
            PositionY = positionY;
            UpdateAt();
        }
        private void SetPositionZ(double? positionZ)
        {
            PositionZ = positionZ;
            UpdateAt();
        }

        private void SetDevice(Device device)
        {
            Device = device ??
                     throw new ArgumentNullException(nameof(device), "Device cannot be null.");
            UpdateAt();
        }

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

        private void SetIsCharging(bool isCharging)
        {
            IsCharging = isCharging;
            UpdateAt();
        }

        private void UpdateAt() { UpdatedAt = DateTime.UtcNow; }
        private void CreateAt() { CreatedAt = DateTime.UtcNow; }
    }
}