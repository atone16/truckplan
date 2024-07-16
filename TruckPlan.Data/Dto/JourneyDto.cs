using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data.Dto
{
    public class JourneyDto : BaseDto
    {
        public Guid TruckDriverId { get; set; }
        public Guid TruckId { get; set; }
        public string StartCountry { get; set; }
        public string EndCountry { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
