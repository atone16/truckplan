using TruckPlan.Data.Dto;
using TruckPlan.Data.Request;

namespace TruckPlan.IManagers
{
    public interface IJourneyManager
    {
        Task<JourneyDto> Get(Guid id);
        Task<JourneyDto> Start(CreateJourneyRequest request);
        Task<JourneyDto> End(Guid id, EndJourneyRequest request);
        Task<bool> Log(Guid id, JourneyGPSRequest request);
        Task<JourneySummaryDto> CalculateJourneySummary(Guid id);
        Task<AgeCountryMonthYearDto> GetByParameters(AgeCountryMonthYearRequest request);
    }
}
