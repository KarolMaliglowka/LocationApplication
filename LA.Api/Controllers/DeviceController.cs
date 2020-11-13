using System;
using System.Threading.Tasks;
using LA.Api.ViewModels.Device;
using LA.Core.Models;
using LA.Core.Repositories;
using LA.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace LA.Api.Controllers
{
    [Route("api/[controller]")]
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
        [HttpPost]
        public async Task<Guid> AddDevice([FromBody] CreateDeviceViewModel device)
        {
            var newDevice = new Device(device.Name);
            return await _deviceRepository.Create(newDevice);
        }
    }
}