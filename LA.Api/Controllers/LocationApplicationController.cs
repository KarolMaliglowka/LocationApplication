using System;
using System.Linq;
using System.Threading.Tasks;

using LA.Api.ViewModels.Location;
using LA.Core.Models;
using LA.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace LA.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class LocationApplicationController : ControllerBase
    {
        public readonly DatabaseContext _context;

        public LocationApplicationController
        (
            DatabaseContext context
        )
        {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<string> GetInfo()
        {
            var test =  _context.Devices.Add(new Device("asdasd"));
            return "Test API" + " " + test.Entity.Id;
        }


        [HttpPost]
        public async Task<string> PostLocation([FromBody] CreateLocationViewModel jsondata)
        {
            //_context.Devices.Add(new Device("asdasd"));
            return "https://www.openstreetmap.org/#map=9/" + jsondata.PositionX + "/" + jsondata.PositionY ;
        }
    }
}