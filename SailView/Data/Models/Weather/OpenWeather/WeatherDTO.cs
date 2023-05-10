using SailView.Data.Models.Weather.OpenWeather.Current;
using SailView.Data.Models.Weather.OpenWeather.Forecast;

namespace SailView.Data.Models.Weather.OpenWeather
{
    public class WeatherDTO
    {
        public LocationDTO? Location { get; set; }

        public CurrentWeatherDTO? CurrentWeather { get; set; }

        public WeatherForecastDTO? WeatherForecast { get; set; }

    }
}
