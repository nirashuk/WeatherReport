using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Controllers;
using Weather.Model;
using System.Linq;

namespace WeatherTest
{
    [TestClass]
    public class WeateherUnitTest
    {
        [TestMethod]
        public async Task GetWeatherInformation_WithValidCityIdAsync()
        {
            WeatherReportsController weather = new WeatherReportsController();

            CityInput cityInput = new CityInput();
            cityInput.City = new List<City>
            {
                new City
                {
                    id = 1275339,
                    name= "Mumbai"
                }
            };
            
            var result = await weather.PostAsync(cityInput);
            Assert.IsNotNull(result.FirstOrDefault().name, "Mumbai");
        }

        //[TestMethod]
        //public async Task GetWeatherInformation_WithInValidCityIdAsync()
        //{
        //    WeatherController weather = new WeatherController();
        //    var result = await weather.GetWeatherInformation(124);
        //    Assert.IsNull(result.name);
        //}
    }
}
