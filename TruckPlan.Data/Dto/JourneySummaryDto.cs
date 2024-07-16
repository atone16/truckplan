using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data.Dto
{
    public class JourneySummaryDto : BaseDto
    {
        public double TotalDistanceKm { get; set; }
        public string Truck { get; set; }
        public string DriverName { get; set; }
        public DateTime DriverBirthdate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan JourneyDuration { get; set; }
        public string StartCountry { get; set; }
        public string EndCountry { get; set; }
        public List<TruckGPSDto> GPSInfo { get; set; }
    }

    public class GPSInfo : BaseDto
    {
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
