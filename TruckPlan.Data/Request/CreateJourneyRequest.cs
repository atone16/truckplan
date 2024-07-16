using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data.Request
{
    public class CreateJourneyRequest
    {
        public Guid TruckDriverId { get; set; }
        public Guid TruckId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
