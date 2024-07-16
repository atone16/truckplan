using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data.Dto
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
