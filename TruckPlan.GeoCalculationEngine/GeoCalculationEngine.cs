using Newtonsoft.Json.Linq;
using TruckPlan.IGeoCalculationEngine;

namespace TruckPlan.GeoCalculationEngine
{
    public class GeoCalculationEngine : ICalculationEngine
    {
        private const double EarthRadiusKm = 6371.0;

        public double HaversineDistance(GeoCoordinate coord1, GeoCoordinate coord2)
        {
            double lat1 = ToRadians(coord1.Latitude);
            double lon1 = ToRadians(coord1.Longitude);
            double lat2 = ToRadians(coord2.Latitude);
            double lon2 = ToRadians(coord2.Longitude);

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dLon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            return EarthRadiusKm * c;
        }

        private double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public async Task<string> GetCountryFromCoordinatesAsync(double latitude, double longitude)
        {
            string url = $"https://nominatim.openstreetmap.org/reverse?format=json&lat={latitude}&lon={longitude}&addressdetails=1";
            string userAgent = "JoseBanzonIII/1.0 (josebanzon@gmail.com)"; // Replace with your app name and contact info

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);

                // Extract the country from the JSON response
                var address = json["address"];
                if (address != null && address["country"] != null)
                {
                    return address["country"].ToString();
                }

                return "Unknown";
            }
        }
    }
}
