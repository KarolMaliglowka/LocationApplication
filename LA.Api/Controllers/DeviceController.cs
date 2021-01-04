using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using LA.Api.ViewModels.Device;
using LA.Core.Models;
using LA.Core.Repositories;
using LA.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace LA.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        public readonly DatabaseContext _context;
        private readonly IDeviceRepository _deviceRepository;

        public DeviceController
        (
            IDeviceRepository deviceRepository,
            DatabaseContext context
        )
        {
            _context = context;
            _deviceRepository = deviceRepository;
        }

        // GET: api/<UserController>
        [Benchmark]
        [HttpPost]
        public async Task<Guid> AddDevice([FromBody]CreateDeviceViewModel device)
        {
            var applicationId = "EF05D54D-2590-4BCB-ADCD-70B8E2B05A98";
            if (device.ApplicationId != applicationId)
            {
                return Guid.Empty;
            }

            if (await _deviceRepository.ExistByPhoneId(device.DeviceInfo.PhoneId))
            {
                return Guid.Empty;
            }

            var newDevice = new Device(device.DeviceInfo.Name, device.DeviceInfo.PhoneId);
            return await _deviceRepository.Create(newDevice);
        }

        [HttpGet("Info")]
        public ContentResult Info()
        {
            return Content("To jest wstepna informacja o dodawaniu urządzeń.");
        }
    }
}
