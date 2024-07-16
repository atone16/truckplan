using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data.Dto
{
    public class AgeCountryMonthYearDto
    {
        public double TotalDistanceKm { get; set; }
        public List<JourneySummaryDto> Journeys { get; set; }
    }
}
