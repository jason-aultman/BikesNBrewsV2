using BikesNBrewsV2.Models;
using System.Text.Json;

namespace BikesNBrewsV2.Services
{
    public class BrewData : IBrewData
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _options;

        public BrewData()
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri("https://api.openbrewerydb.org/") };
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        }


        public List<Brewery> GetBreweriesByCityState(string City, string State)
        {
            HttpResponseMessage request = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            string requestString;
            List<Brewery> serialized = new List<Brewery>();

            if (City != null && State != null)
            {
                var standardizedCity = City.Replace(' ', '_');
                request = _httpClient.GetAsync($"breweries?by_city={standardizedCity}&by_state={State}&per_page=50").Result;

            }
            if (request.StatusCode == System.Net.HttpStatusCode.OK)
            {
                requestString = request.Content.ReadAsStringAsync().Result;
                serialized = JsonSerializer.Deserialize<List<Brewery>>(requestString, _options);

            }
            var sList = new List<Brewery>();
            //var bvm = new BrewViewModel() { Brewery = new Brewery(), Breweries = serialized };
            return serialized;
        }

        public List<Brewery> GetBreweriesByZip(string Zip)
        {
            HttpResponseMessage request = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            string requestString;
            List<Brewery> serialized = new List<Brewery>();

            if (Zip != null)
            {
                request = _httpClient.GetAsync($"breweries?by_postal={Zip}&per_page=50").Result;
            }
            if (request.StatusCode == System.Net.HttpStatusCode.OK)
            {
                requestString = request.Content.ReadAsStringAsync().Result;
                serialized = JsonSerializer.Deserialize<List<Brewery>>(requestString, _options);

            }
            var sList = new List<Brewery>();
            // var bvm = new BrewViewModel() { Brewery = new Brewery(), Breweries = serialized };
            return serialized;

        }

        List<Brewery> IBrewData.GetBreweriesWithInRange(Coordinate coordinate, double Miles)
        {
            HttpResponseMessage request = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            string requestString;
            List<Brewery> serialized = new List<Brewery>();

            if (coordinate != null && Miles>0)
            {
                request = _httpClient.GetAsync($"breweries?by_dist={coordinate.Latitude},{coordinate.Longitude}").Result;
            }
            if (request.StatusCode == System.Net.HttpStatusCode.OK)
            {
                requestString = request.Content.ReadAsStringAsync().Result;
                serialized = JsonSerializer.Deserialize<List<Brewery>>(requestString, _options);

            }
            var sList = new List<Brewery>();
            // var bvm = new BrewViewModel() { Brewery = new Brewery(), Breweries = serialized };
            return serialized;

        }
    }
}
