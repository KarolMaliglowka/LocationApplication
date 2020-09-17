using System;
using System.Threading.Tasks;

using LA.Api.ViewModels.Location;

using Microsoft.AspNetCore.Mvc;

namespace LA.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class LocationApplicationController : ControllerBase
    {
        //public readonly DatabaseContext _context;

        //public LocationApplicationController(DatabaseContext context)
        //{
        //    _context = context;
        //}

        // GET: api/<UserController>
        [HttpGet]
        public async Task<string> GetInfo()
        {
            return "Test API";
        }

        [HttpPost]
        public async Task<string> PostLocation([FromBody] CreateLocationViewModel jsondata)
        {
            return "https://www.openstreetmap.org/#map=9/" + jsondata.PositionX + "/" + jsondata.PositionY ;

            //"https://www.openstreetmap.org/#map=9/50.6015/17.6825
        }
    }
}