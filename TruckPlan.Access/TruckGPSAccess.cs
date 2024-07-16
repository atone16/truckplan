using Microsoft.EntityFrameworkCore;
using TruckPlan.Data;
using TruckPlan.EntityFramework;
using TruckPlan.IAccess;

namespace TruckPlan.Access
{
    public class TruckGPSAccess : BaseAccess<TruckGPS>, ITruckGPSAccess
    {
        private readonly ApplicationDBContext applicationDBContext;

        public TruckGPSAccess(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public async Task<List<TruckGPS>> GetByJourneyId(Guid journeyId)
        {
            return await this.applicationDBContext.TruckGPS
                .Where(x => x.JourneyId == journeyId)
                .OrderBy(x => x.DateCreated)
                .ToListAsync();
        }
    }
}
