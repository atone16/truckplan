using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Data
{
    public class BaseData
    {
        public Guid Id { get; set; }
        public DateTime DateCreated {  get; set; }
        public bool IsArchived { get; set; } = false;
    }
}
