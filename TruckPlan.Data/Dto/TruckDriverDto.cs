using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data.Dto
{
    public class TruckDriverDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
