using System.Threading.Tasks;
using LA.Api.ViewModels.Device;
using LA.Core.Models;
using LA.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LA.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceController
        (
            IDeviceRepository deviceRepository
        )
        {
            _deviceRepository = deviceRepository;
        }

        [HttpPost("AddDevice")]
        public async Task<ActionResult> AddDevice([FromBody] CreateDeviceViewModel device)
        {
            if (await _deviceRepository.ExistByPhoneId(device.PhoneId))
            {
                return Content("This phone is already registered.");
            }

            var newDevice = new Device(device.Name, device.PhoneId);
            await _deviceRepository.Create(newDevice);

            return Ok(newDevice.Id);
        }

        [HttpGet]
        public ContentResult Info()
        {
            return Content("API information:\n - adding a device");
        }
    }
}