using BikesNBrewsV2.Models;
using System.Text.Json;
using static BikesNBrewsV2.Models.Root;

namespace BikesNBrewsV2.Services
{
    public class GeoLocation : IGeoCachable
    {
        public Coordinate GetCoordinates(string Address, string City, string State, string Zip)
        {
            var normalizedAddress = Address.Replace(" ", "%20");
            var httpClient = new HttpClient() { BaseAddress = new Uri("https://api.geoapify.com/v1/geocode/") };
            var request = httpClient.GetAsync($"search?text={normalizedAddress}%2C{City}%2C{State}%20{Zip}&apiKey=9b261bb4de5e4edbab8dc28ad1c3583f").Result.Content.ReadAsStringAsync().Result;
            var deserialized = JsonSerializer.Deserialize<Root>(request, new JsonSerializerOptions() { PropertyNameCaseInsensitive=true});
            var coords = deserialized.Features.SingleOrDefault();
            var coordinates = new Coordinate();
            coordinates.Longitude = coords.Properties.Lon;
            coordinates.Latitude = coords.Properties.Lat;

            return coordinates;
        }
    }
}
