using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data
{
    public class JourneySummary : BaseData
    {
        public double TotalDistanceKm { get; set; }
        public string StartCountry { get; set; }
        public string EndCountry { get; set; }
        public string Truck { get; set; }
        public string DriverName { get; set; }
        public DateTime DriverBirthdate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan JourneyDuration { get; set; }
    }
}
