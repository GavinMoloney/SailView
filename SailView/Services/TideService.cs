﻿using Newtonsoft.Json;


namespace SailView.Services
{
    public class TideService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiKey;

        public TideService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            ApiKey = configuration["TideAPIKey"];
        }

        public async Task<(TideData tideData, string errorMessage)> GetTideData(double lat, double lon)
        {
            try
            {
                var apiUrl = $"https://www.worldtides.info/api/v3?heights&extremes&key={ApiKey}&lat={lat}&lon={lon}";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var tideData = JsonConvert.DeserializeObject<TideData>(jsonResponse);
                    return (tideData, null);
                }
                else
                {
                    return (null, $"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                return (null, $"Error: {ex.Message}");
            }
        }
    }

    public class TideData
    {
        [JsonProperty("heights")]
        public List<TideStation> Heights { get; set; }

        [JsonProperty("extremes")]
        public List<TideStation> Extremes { get; set; }
    }

    public class TideStation
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("dt")]
        public long Timestamp { get; set; }

        public DateTime Date => DateTimeOffset.FromUnixTimeSeconds(Timestamp).ToLocalTime().DateTime;
    }

}
