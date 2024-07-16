using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruckPlan.Data.Request;
using TruckPlan.IManagers;

namespace TruckPlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyManager journeyManager;

        public JourneyController(IJourneyManager journeyManager)
        {
            this.journeyManager = journeyManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var truck = await this.journeyManager.Get(id);
            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start([FromBody] CreateJourneyRequest request)
        {
            var result = await this.journeyManager.Start(request);
            return Ok(result);
        }

        [HttpPost("{id}/end")]
        public async Task<IActionResult> End(Guid id, [FromBody] EndJourneyRequest request)
        {
            var result = await this.journeyManager.End(id, request);
            return Ok(result);
        }

        [HttpPost("{id}/log")]
        public async Task<IActionResult> Log(Guid id, [FromBody] JourneyGPSRequest request)
        {
            var result = await this.journeyManager.Log(id, request);
            return Ok(result);
        }

        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> CalculateTotalDistance(Guid id)
        {
            var result = await this.journeyManager.CalculateJourneySummary(id);
            return Ok(result);
        }

        [HttpPost("FindByAgeCountryMonthYear")]
        public async Task<IActionResult> GetByParameters([FromBody]AgeCountryMonthYearRequest request)
        {
            var result = await this.journeyManager.GetByParameters(request);
            return Ok(result);
        }


    }
}
