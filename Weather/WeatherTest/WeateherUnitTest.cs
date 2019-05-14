using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Weather.Controllers;

namespace WeatherTest
{
    [TestClass]
    public class WeateherUnitTest
    {
        [TestMethod]
        public async Task GetWeatherInformation_WithValidCityIdAsync()
        {
            WeatherController weather = new WeatherController();
            var result = await weather.GetWeatherInformation(1275339);
            Assert.IsNotNull(result.name, "Mumbai");
        }

        [TestMethod]
        public async Task GetWeatherInformation_WithInValidCityIdAsync()
        {
            WeatherController weather = new WeatherController();
            var result = await weather.GetWeatherInformation(124);
            Assert.IsNull(result.name);
        }
    }
}
