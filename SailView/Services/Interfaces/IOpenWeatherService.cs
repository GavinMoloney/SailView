using SailView.Data.Models.Weather;
using SailView.Data.Models.Weather.OpenWeather;

namespace SailView.Services.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<IEnumerable<LocationDTO>?> GetLocations(LocationSearchDTO locationSearchDTO);
        Task<WeatherDTO> GetWeather(LocationDTO location);
    }
}
