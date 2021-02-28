namespace LA.Api.ViewModels.Location
{
    public class LocationInfoViewModel
    {
        public string PositionX { get; set; }
        public string PositionY { get; set; }
        public string PositionZ { get; set; }
        public int BatteryChargeStatus { get; set; }
        public bool IsCharging { get; set; }
    }
}