namespace TruckPlan.IGeoCalculationEngine
{
    public interface ICalculationEngine
    {
        double HaversineDistance(GeoCoordinate coord1, GeoCoordinate coord2);
        Task<string> GetCountryFromCoordinatesAsync(double latitude, double longitude);
    }
}
