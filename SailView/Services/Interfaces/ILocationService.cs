using System.Text;
using System.Text.Json;

namespace SailView.Services.Interfaces
{
    public interface ILocationService
    {
        Task SendLocation(double latitude, double longitude);
    }

    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendLocation(double latitude, double longitude)
        {
            var location = new
            {
                latitude = latitude,
                longitude = longitude
            };
            var json = JsonSerializer.Serialize(location);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("/api/location", content);
        }
    }



}
