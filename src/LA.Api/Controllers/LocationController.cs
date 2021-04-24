using System.Threading.Tasks;
using LA.Api.ViewModels.Location;
using LA.Core.Models;
using LA.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LA.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        
        private readonly ILocationRepository _locationRepository;
        private readonly IDeviceRepository _deviceRepository;
        
        public LocationController
        (
            ILocationRepository locationRepository,
            IDeviceRepository deviceRepository
        )
        {
            _locationRepository = locationRepository;
            _deviceRepository = deviceRepository;
        }

        [HttpGet]
        public ContentResult Info()
        {
            return Content("API information:\n - adding location");
        }
        
        [HttpPost("AddLocation")]
        public async Task<ActionResult> AddLocation([FromBody]CreateLocationViewModel location)
        {
            
            if (!await _deviceRepository.ExistByPhoneId(location.DeviceId))
            {
                return Content("Wrong device ID.");
            }

            var device = await _deviceRepository.GetById(location.DeviceId);

            var newLocation = new Location(
                device,
                double.Parse(location.LocationInfo.PositionX),
                double.Parse(location.LocationInfo.PositionY),
                double.Parse(location.LocationInfo.PositionZ),
                location.LocationInfo.BatteryChargeStatus,
                location.LocationInfo.IsCharging
                );
                
            await _locationRepository.Create(newLocation);
            
            return Ok(newLocation.Id);
        }
    }
}