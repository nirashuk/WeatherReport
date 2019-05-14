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
        // GET: api/WeatherReports
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WeatherReports/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

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
                foreach (var city in cityInput.City)
                {
                    var response = await client.GetAsync("/data/2.5/weather?id=" + city.id + "&appid=aa69195559bd4f88d79f9aadeb77a8f6");
                    if (response.IsSuccessStatusCode)
                    {
                        WeatherReport weatherReport = new WeatherReport();
                        weatherReport = await response.Content.ReadAsAsync<WeatherReport>();
                        weatherReportList.Add(weatherReport);
                        //Save this file in JsonFormat in Output Directory
                        //string json = JsonConvert.SerializeObject(weatherReport);
                        //System.IO.File.WriteAllText(@"~/Weather/Weather/OutputFile/" + weatherReport.name + DateTime.UtcNow.ToLongDateString() + ".json", json);
                    }
                }
                return weatherReportList;
            }
        }

        // PUT: api/WeatherReports/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
