using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data
{
    public class Truck : BaseData
    {
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
