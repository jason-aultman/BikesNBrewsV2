using System.Text.Json.Serialization;

namespace BikesNBrewsV2.Models
{
   
    
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Datasource
        {
            [JsonPropertyName("sourcename")]
            public string Sourcename { get; set; }

            [JsonPropertyName("attribution")]
            public string Attribution { get; set; }

            [JsonPropertyName("license")]
            public string License { get; set; }

            [JsonPropertyName("url")]
            public string Url { get; set; }
        }

        public class Rank
        {
            [JsonPropertyName("importance")]
            public double Importance { get; set; }

            [JsonPropertyName("popularity")]
            public double Popularity { get; set; }

            [JsonPropertyName("confidence")]
            public int Confidence { get; set; }

            [JsonPropertyName("confidence_city_level")]
            public int ConfidenceCityLevel { get; set; }

            [JsonPropertyName("confidence_street_level")]
            public int ConfidenceStreetLevel { get; set; }

            [JsonPropertyName("match_type")]
            public string MatchType { get; set; }
        }

        public class Properties
        {
            [JsonPropertyName("datasource")]
            public Datasource Datasource { get; set; }

            [JsonPropertyName("housenumber")]
            public string Housenumber { get; set; }

            [JsonPropertyName("street")]
            public string Street { get; set; }

            [JsonPropertyName("suburb")]
            public string Suburb { get; set; }

            [JsonPropertyName("city")]
            public string City { get; set; }

            [JsonPropertyName("county")]
            public string County { get; set; }

            [JsonPropertyName("state")]
            public string State { get; set; }

            [JsonPropertyName("postcode")]
            public string Postcode { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("country_code")]
            public string CountryCode { get; set; }

            [JsonPropertyName("lon")]
            public double Lon { get; set; }

            [JsonPropertyName("lat")]
            public double Lat { get; set; }

            [JsonPropertyName("state_code")]
            public string StateCode { get; set; }

            [JsonPropertyName("formatted")]
            public string Formatted { get; set; }

            [JsonPropertyName("address_line1")]
            public string AddressLine1 { get; set; }

            [JsonPropertyName("address_line2")]
            public string AddressLine2 { get; set; }

            [JsonPropertyName("category")]
            public string Category { get; set; }

            [JsonPropertyName("result_type")]
            public string ResultType { get; set; }

            [JsonPropertyName("rank")]
            public Rank Rank { get; set; }

            [JsonPropertyName("place_id")]
            public string PlaceId { get; set; }
        }

        public class Geometry
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("coordinates")]
            public List<double> Coordinates { get; set; }
        }

        public class Feature
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("properties")]
            public Properties Properties { get; set; }

            [JsonPropertyName("geometry")]
            public Geometry Geometry { get; set; }

            [JsonPropertyName("bbox")]
            public List<double> Bbox { get; set; }
        }

        public class Parsed
        {
            [JsonPropertyName("housenumber")]
            public string Housenumber { get; set; }

            [JsonPropertyName("street")]
            public string Street { get; set; }

            [JsonPropertyName("postcode")]
            public string Postcode { get; set; }

            [JsonPropertyName("district")]
            public string District { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("expected_type")]
            public string ExpectedType { get; set; }
        }

        public class Query
        {
            [JsonPropertyName("text")]
            public string Text { get; set; }

            [JsonPropertyName("parsed")]
            public Parsed Parsed { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("features")]
            public List<Feature> Features { get; set; }

            [JsonPropertyName("query")]
            public Query Query { get; set; }
        }


    }

