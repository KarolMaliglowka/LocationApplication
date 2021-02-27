using System;
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
        public async Task<ActionResult> AddDevice([FromBody]CreateDeviceViewModel device)
        {
            var applicationId = "EF05D54D-2590-4BCB-ADCD-70B8E2B05A98";
            
            if (device.ApplicationId != applicationId)
            {
                return NotFound(Guid.Empty);
            }

            if (await _deviceRepository.ExistByPhoneId(device.DeviceInfo.PhoneId))
            {
                return NotFound(Guid.Empty);
            }

            var newDevice = new Device(device.DeviceInfo.Name, device.DeviceInfo.PhoneId);
            await _deviceRepository.Create(newDevice);
            
            return Ok(newDevice.Id);//
        }

        [HttpGet]
        public ContentResult Info()
        {
            return Content("To jest wstepna informacja o dodawaniu urządzeń.");
        }
    }
}
