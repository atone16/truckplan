using AutoMapper;
using TruckPlan.Data;
using TruckPlan.Data.Dto;
using TruckPlan.Data.Request;

namespace TruckPlan.Core
{
    public class TruckPlanMapperProfile : Profile
    {
        public TruckPlanMapperProfile() 
        {
            CreateMap<TruckDriverRequest, TruckDriver>();
            CreateMap<TruckDriver, TruckDriverDto>();

            CreateMap<TruckRequest, Truck>();
            CreateMap<Truck, TruckDto>();

            CreateMap<Journey, JourneyDto>();
            CreateMap<CreateJourneyRequest, Journey>();

            CreateMap<JourneySummary, JourneySummaryDto>();
        }
    }
}
