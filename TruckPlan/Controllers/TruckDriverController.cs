using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruckPlan.Data;
using TruckPlan.Data.Request;
using TruckPlan.IManagers;

namespace TruckPlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckDriverController : ControllerBase
    {
        private readonly ITruckDriverManager truckDriverManager;

        public TruckDriverController(ITruckDriverManager truckDriverManager) 
        {
            this.truckDriverManager = truckDriverManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var truck = await this.truckDriverManager.Get(id);
            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var truck = await this.truckDriverManager.GetAll();
            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        [HttpPost("{id}/archive")]
        public async Task<IActionResult> Archive(Guid id)
        {
            var result = await this.truckDriverManager.Archive(id);
            return Ok(result);
        }

        [HttpPost("{id}/unarchive")]
        public async Task<IActionResult> Unarchive(Guid id)
        {
            var result = await this.truckDriverManager.Unarchive(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TruckDriverRequest request)
        {
            var truckDriver = await this.truckDriverManager.Create(request);
            return Ok(truckDriver);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(Guid id, [FromBody]TruckDriverRequest request)
        {
            var result = await this.truckDriverManager.Update(id, request);
            return Ok(result);
        }
    }
}
