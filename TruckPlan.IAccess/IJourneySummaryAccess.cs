using TruckPlan.Data;

namespace TruckPlan.IAccess
{
    public interface IJourneySummaryAccess : IBaseAccess<JourneySummary>
    {
        Task<List<JourneySummary>> GetByParameters(int greaterThanAge, string country, int year, int month);
    }
}
