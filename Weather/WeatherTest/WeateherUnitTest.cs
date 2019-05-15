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
            cityInput.Cities = new List<City>
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

        [TestMethod]
        public async Task GetWeatherInformation_WithInValidCityIdAsync()
        {
            WeatherReportsController weather = new WeatherReportsController();

            CityInput cityInput = new CityInput();
            cityInput.Cities = new List<City>
            {
                new City
                {
                    id = 12753,
                    name= "Mumbai"
                }
            };

            var result = await weather.PostAsync(cityInput);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public async Task GetWeatherInformation_WithMultipleValidCityIdAsync()
        {
            WeatherReportsController weather = new WeatherReportsController();

            CityInput cityInput = new CityInput();
            cityInput.Cities = new List<City>
            {
                new City
                {
                    id = 1275339,
                    name= "Mumbai"
                },
                new City
                {
                    id = 1273294,
                    name= "Delhi"
                },
                new City
                {
                    id = 292223,
                    name= "Dubai"
                }
            };

            var result = await weather.PostAsync(cityInput);
            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public async Task GetWeatherInformation_WithCombinationOf_Valid_InvalidCityIdAsync()
        {
            WeatherReportsController weather = new WeatherReportsController();

            CityInput cityInput = new CityInput();
            cityInput.Cities = new List<City>
            {
                new City
                {
                    id = 127539, //Invalid
                    name= "Mumbai"
                },
                new City
                {
                    id = 1273294, //Valid
                    name= "Delhi"
                },
                new City
                {
                    id = 29223, //Invalid
                    name= "Dubai"
                }
            };

            var result = await weather.PostAsync(cityInput);
            //Weather details corresponding to valid City id returns in list
            Assert.IsFalse(result.Count == 3); //Count is 1
        }
    }
}
