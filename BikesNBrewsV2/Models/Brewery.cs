using System.Text.Json.Serialization;

namespace BikesNBrewsV2.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Brewery
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("brewery_type")]
        public string BreweryType { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("address_2")]
        public object Address2 { get; set; }

        [JsonPropertyName("address_3")]
        public object Address3 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("county_province")]
        public object CountyProvince { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website_url")]
        public string WebsiteUrl { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }


}
