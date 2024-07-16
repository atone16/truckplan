using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data.Request
{
    public class AgeCountryMonthYearRequest
    {
        public int Age { get; set; }
        public string Country { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
