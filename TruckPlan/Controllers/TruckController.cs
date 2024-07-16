using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruckPlan.Data.Request;
using TruckPlan.IManagers;

namespace TruckPlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckManager truckManager;

        public TruckController(ITruckManager truckManager)
        {
            this.truckManager = truckManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var truck = await this.truckManager.Get(id);
            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var truck = await this.truckManager.GetAll();
            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        [HttpPost("{id}/archive")]
        public async Task<IActionResult> Archive(Guid id)
        {
            var result = await this.truckManager.Archive(id);
            return Ok(result);
        }

        [HttpPost("{id}/unarchive")]
        public async Task<IActionResult> Unarchive(Guid id)
        {
            var result = await this.truckManager.Unarchive(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TruckRequest request)
        {
            var result = await this.truckManager.Create(request);
            return Ok(result);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TruckRequest request)
        {
            var result = await this.truckManager.Update(id, request);
            return Ok(result);
        }
    }
}
