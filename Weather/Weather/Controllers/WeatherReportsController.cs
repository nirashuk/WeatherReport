using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Weather.Model;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherReportsController : ControllerBase
    {
        // POST: api/WeatherReports
        [HttpPost]
        public async Task<List<WeatherReport>> PostAsync([FromBody] CityInput cityInput)
        {
            List<WeatherReport> weatherReportList = new List<WeatherReport>();
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                foreach (var city in cityInput.Cities)
                {
                    var response = await client.GetAsync("/data/2.5/weather?id=" + city.id + "&appid=aa69195559bd4f88d79f9aadeb77a8f6");
                    if (response.IsSuccessStatusCode)
                    {
                        WeatherReport weatherReport = new WeatherReport();
                        weatherReport = await response.Content.ReadAsAsync<WeatherReport>();
                        weatherReportList.Add(weatherReport);
                    }
                }
                return weatherReportList;
            }
        }
    }
}
