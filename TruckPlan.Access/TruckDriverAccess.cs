using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data;
using TruckPlan.EntityFramework;
using TruckPlan.IAccess;

namespace TruckPlan.Access
{
    public class TruckDriverAccess : BaseAccess<TruckDriver>, ITruckDriverAccess
    {
        public TruckDriverAccess(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
        }
    }
}
