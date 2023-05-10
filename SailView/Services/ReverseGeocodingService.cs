using System.Text.Json;
using System.Text.Json.Serialization;


namespace SailView.Services
{
    public class ReverseGeocodingService
    {
        private readonly string _baseApiUrl = "https://maps.googleapis.com/maps/api/geocode/json";
        private readonly string _apiKey;

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public ReverseGeocodingService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["GoogleMapsAPIKey"];
        }

        public async Task<string?> GetCityNameFromCoordinatesAsync(double latitude, double longitude)
        {
            var requestUrl = $"{_baseApiUrl}?latlng={latitude},{longitude}&key={_apiKey}";
            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return ExtractCityNameFromJson(responseContent);
            }

            return null;
        }

        public string? ExtractCityNameFromJson(string json)
        {
            using var document = JsonDocument.Parse(json);
            var results = document.RootElement.GetProperty("results");
            foreach (var result in results.EnumerateArray())
            {
                var addressComponents = result.GetProperty("address_components");
                foreach (var component in addressComponents.EnumerateArray())
                {
                    var types = component.GetProperty("types");
                    foreach (var type in types.EnumerateArray())
                    {
                        if (type.GetString() == "locality" || type.GetString() == "postal_town")
                        {
                            return component.GetProperty("long_name").GetString();
                        }
                    }
                }
            }

            return null;
        }



        public async Task<ReverseGeocodingResult> GetAddressFromCoordinatesAsync(double latitude, double longitude)
        {

            var requestUrl = $"{_baseApiUrl}?latlng={latitude},{longitude}&key={_apiKey}";
            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GoogleMapsGeocodingResponse>(responseContent, _jsonOptions);


                var formattedAddress = result.Results.FirstOrDefault()?.FormattedAddress;

                var cityName = ExtractCityNameFromJson(responseContent);

                return new ReverseGeocodingResult { DisplayName = formattedAddress, CityName = cityName };
            }
            Console.WriteLine($"Request failed with status code: {response.StatusCode}");
            return null;
        }
    }


    public class ReverseGeocodingResult
    {
        public string DisplayName { get; set; }
        public string CityName { get; set; }

    }
    public class GoogleMapsGeocodingResponse
    {
        public List<GeocodingResult> Results { get; set; }
    }

    public class GeocodingResult
    {
        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; set; }

    }



}
