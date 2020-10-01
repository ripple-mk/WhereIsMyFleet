using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhereIsMyFleet.Services.Features.Fleet;
using WhereIsMyFleet.Services.Features.ToDos;

namespace WhereIsMyFleet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FleetController : BaseController
    {
        [HttpGet]
        [Route("[action]")]
        public async Task<ListDrones.Response> List()
            => await Handle(new ListDrones.Request());

        [HttpPost]
        [Route("[action]")]
        public async Task<AddDrone.Response> AddDrone([FromBody] AddDrone.Request request)
            => await Handle(request);
    }
}
