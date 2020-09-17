using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LA.Infrastructure.Data;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LA.Api.Controllers
{
    [Route("[controller]")]
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
        [Route("{tekst}")]
        public async Task<string> PostInfo(string tekst)
        {
            return "to jest Twój tekst: " + tekst;
        }

    }
}
