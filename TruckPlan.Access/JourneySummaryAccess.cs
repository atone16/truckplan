using Microsoft.EntityFrameworkCore;
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
    public class JourneySummaryAccess : BaseAccess<JourneySummary>, IJourneySummaryAccess
    {
        private readonly ApplicationDBContext applicationDBContext;
        public JourneySummaryAccess(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public async Task<List<JourneySummary>> GetByParameters(int greaterThanAge, string country, int year, int month)
        {
            DateTime currentDate = new DateTime(year, month, 1);

            return await this.applicationDBContext.JourneySummary.Where(
                x => 
                (x.StartCountry == country || x.EndCountry == country) && 
                (x.EndDate.Year == year && x.EndDate.Month == month) &&
                (x.StartDate.Year == year && x.StartDate.Month == month) &&
                (currentDate.Year - x.DriverBirthdate.Year > greaterThanAge)
                ).ToListAsync();
        }
    }
}
