using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data.Request
{
    public class TruckRequest
    {
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
