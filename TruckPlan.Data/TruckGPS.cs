using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data
{
    public class TruckGPS : BaseData
    {
        public Guid JourneyId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
