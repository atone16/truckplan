using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data;

namespace TruckPlan.IAccess
{
    public interface ITruckGPSAccess : IBaseAccess<TruckGPS>
    {
        Task<List<TruckGPS>> GetByJourneyId(Guid journeyId);
    }
}
