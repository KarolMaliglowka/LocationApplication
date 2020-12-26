using System.Threading.Tasks;
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
            return "Test API";
        }
    }
}