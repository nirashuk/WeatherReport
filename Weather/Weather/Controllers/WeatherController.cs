using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Model;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // GET: api/Weather/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<WeatherReport> GetWeatherInformation(int id)
        {
            WeatherReport weatherReport = new WeatherReport();

            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("/data/2.5/weather?id=" + id + "&appid=aa69195559bd4f88d79f9aadeb77a8f6");
                if (response.IsSuccessStatusCode)
                {
                    weatherReport = await response.Content.ReadAsAsync<WeatherReport>();
                }
            }
            return weatherReport;
        }
    }
}
