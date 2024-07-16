using AutoMapper;
using TruckPlan.Data;
using TruckPlan.Data.Dto;
using TruckPlan.Data.Request;
using TruckPlan.IAccess;
using TruckPlan.IGeoCalculationEngine;
using TruckPlan.IManagers;

namespace TruckPlan.Managers
{
    public class JourneyManager : IJourneyManager
    {
        private readonly IJourneyAccess journeyAccess;
        private readonly ITruckGPSAccess truckGPSAccess;
        private readonly ITruckDriverAccess driverAccess;
        private readonly ITruckAccess truckAccess;
        private readonly ICalculationEngine calculationEngine;
        private readonly IJourneySummaryAccess journeySummaryAccess;
        private readonly IMapper mapper;

        public JourneyManager(
            IJourneyAccess journeyAccess,
            ITruckGPSAccess truckGPSAccess,
            ITruckDriverAccess driverAccess,
            ITruckAccess truckAccess,
            IJourneySummaryAccess journeySummaryAccess,
            ICalculationEngine calculationEngine,
            IMapper mapper) 
        {
            this.journeyAccess = journeyAccess;
            this.truckGPSAccess =  truckGPSAccess;
            this.driverAccess = driverAccess;
            this.truckAccess = truckAccess;
            this.journeySummaryAccess = journeySummaryAccess;
            this.calculationEngine = calculationEngine;
            this.mapper = mapper;
        }

        public async Task<JourneyDto> Get(Guid id)
        {
            var journey = await this.journeyAccess.GetByIdAsync(id);
            return this.mapper.Map<JourneyDto>(journey);
        }

        public async Task<JourneyDto> Start(CreateJourneyRequest request)
        {
            // Validate TruckDriver
            var truckDriver = await this.driverAccess.GetByIdAsync(request.TruckDriverId);

            // Validate Truck
            var truck = await this.truckAccess.GetByIdAsync(request.TruckId);

            if (truckDriver == null || truck == null)
            {
                throw new Exception("Invalid truck or truck driver");
            }

            if (truckDriver.IsArchived || truck.IsArchived)
            {
                throw new Exception("Invalid truck or truck driver");
            }

            if (!IsValid(request.Longitude, request.Latitude))
            {
                throw new Exception("Invalid longitude or latitude");
            }

            try
            {
                var journeyInput = this.mapper.Map<Journey>(request);

                journeyInput.StartDate = DateTime.Now;
                journeyInput.StartCountry = await this.calculationEngine.GetCountryFromCoordinatesAsync(request.Latitude, request.Longitude);
                var journey = await this.journeyAccess.CreateAsync(journeyInput);

                var truckGPS = await this.truckGPSAccess.CreateAsync(new TruckGPS
                {
                    JourneyId = journey.Id,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                });

                return this.mapper.Map<JourneyDto>(journey);
            }
            catch (Exception ex)
            {
                throw new Exception("Error when creating journey.");
            }
        }

        public async Task<JourneyDto> End(Guid id, EndJourneyRequest request)
        {
            // Validate Journey exists
            var journey = await this.journeyAccess.GetByIdAsync(id);

            if (journey == null)
            {
                throw new Exception("Invalid journey");
            }

            if (journey.IsArchived)
            {
                throw new Exception("Can't end an archived journey");
            }

            if (journey.EndDate != null)
            {
                throw new Exception("Can't end an ended journey");
            }

            if (!IsValid(request.Longitude, request.Latitude))
            {
                throw new Exception("Invalid longitude or latitude");
            }

            try
            {
                journey.EndCountry = await this.calculationEngine.GetCountryFromCoordinatesAsync(request.Latitude, request.Longitude);
                journey.EndDate = DateTime.Now;
                await this.journeyAccess.UpdateAsync(journey);

                var truckGPS = await this.truckGPSAccess.CreateAsync(new TruckGPS
                {
                    JourneyId = journey.Id,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                });

                return this.mapper.Map<JourneyDto>(journey);
            }
            catch (Exception ex)
            {
                throw new Exception("Error when ending the journey.");
            }
        }

        public async Task<bool> Log(Guid id, JourneyGPSRequest request)
        {
            // Validate Journey exists
            var journey = await this.journeyAccess.GetByIdAsync(id);

            if (journey == null)
            {
                throw new Exception("Invalid journey");
            }

            if (journey.IsArchived)
            {
                throw new Exception("Can't log an archived journey");
            }

            if (!IsValid(request.Longitude, request.Latitude))
            {
                throw new Exception("Invalid longitude or latitude");
            }

            try
            {
                var truckGPS = await this.truckGPSAccess.CreateAsync(new TruckGPS
                {
                    JourneyId = journey.Id,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                });

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error when ending the journey." + ex.Message);
            }

        }

        public async Task<JourneySummaryDto> CalculateJourneySummary(Guid id)
        {
            // Validate Journey exists
            var journey = await this.journeyAccess.GetByIdAsync(id);

            if (journey == null)
            {
                throw new Exception("Journey does not exist.");
            }

            if (journey.IsArchived)
            {
                throw new Exception("Journey is already archived.");
            }

            if (journey.EndDate == null)
            {
                throw new Exception("Journey has not yet ended.");
            }

            var truck = await this.truckAccess.GetByIdAsync(journey.TruckId);
            var driver = await this.driverAccess.GetByIdAsync(journey.TruckDriverId);
            var gpsList = await this.truckGPSAccess.GetByJourneyId(journey.Id);

            var journeySummary = await this.journeySummaryAccess.CreateAsync(new JourneySummary
            {
                Id = journey.Id,
                Truck = $"{truck.Make} - {truck.Model} - {truck.PlateNumber}",
                DriverName = $"{driver.FirstName} {driver.LastName}",
                DriverBirthdate = driver.BirthDate,
                DateCreated = journey.StartDate,
                StartDate = journey.StartDate,
                EndDate = journey.EndDate.Value,
                JourneyDuration = this.GetTotalDuration(journey),
                TotalDistanceKm = GetTotalDistance(gpsList),
                EndCountry = journey.EndCountry,
                StartCountry = journey.StartCountry,
            });

            var journeySummaryDto = this.mapper.Map<JourneySummaryDto>(journeySummary);
            journeySummaryDto.GPSInfo = await this.GenerateGPSInfo(gpsList);
            return journeySummaryDto;
        }

        private double GetTotalDistance(List<TruckGPS> gpsList)
        {
            double totalDistance = 0;

            for (int i = 0; i < gpsList.Count - 1; i++)
            {
                var gps1 = gpsList[i];
                var gps2 = gpsList[i + 1];

                var coord1 = new GeoCoordinate(gps1.Latitude, gps1.Longitude);
                var coord2 = new GeoCoordinate(gps2.Latitude, gps2.Longitude);

                totalDistance += this.calculationEngine.HaversineDistance(coord1, coord2);
            }

            return totalDistance;
        }

        private TimeSpan GetTotalDuration(Journey journey)
        {
            return journey.EndDate.Value - journey.StartDate;
        }

        private bool IsValid(double longitude, double latitude)
        {
            return IsValidLatitude(latitude) && IsValidLongitude(longitude);
        }

        private static bool IsValidLatitude(double latitude)
        {
            return latitude >= -90 && latitude <= 90;
        }

        private static bool IsValidLongitude(double longitude)
        {
            return longitude >= -180 && longitude <= 180;
        }

        private async Task<List<TruckGPSDto>> GenerateGPSInfo(List<TruckGPS> gpsList)
        {
            var truckGPSList = new List<TruckGPSDto>();
            foreach (var gps in gpsList)
            {
                var country = await this.calculationEngine.GetCountryFromCoordinatesAsync(gps.Latitude, gps.Longitude);
                truckGPSList.Add(new TruckGPSDto
                {
                    Latitude = gps.Latitude,
                    Longitude = gps.Longitude,
                    Country = country
                });
            }
            return truckGPSList;
        }

        public async Task<AgeCountryMonthYearDto> GetByParameters(AgeCountryMonthYearRequest request)
        {
            if (request.Year > 1900 && request.Month > 0 && request.Month < 13 && !string.IsNullOrEmpty(request.Country)
                && request.Age > 0)
            {
                var result = await this.journeySummaryAccess.GetByParameters(request.Age, request.Country, request.Year, request.Month);
                var journeySummaryDto = this.mapper.Map<List<JourneySummaryDto>>(result);
                var totalDistanceInKm = journeySummaryDto.Select(x => x.TotalDistanceKm).Sum();

                return new AgeCountryMonthYearDto
                {
                    Journeys = journeySummaryDto,
                    TotalDistanceKm = totalDistanceInKm
                };
            }

            throw new ArgumentException("Invalid parameters passed.");
        }
    }
}
