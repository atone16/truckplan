using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data.Dto
{
    public class TruckDto : BaseDto
    {
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
