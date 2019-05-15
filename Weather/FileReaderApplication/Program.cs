using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Weather.Controllers;
using Weather.Model;

namespace FileReaderApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WeatherReportsController weather = new WeatherReportsController();

                Console.WriteLine("City File Received Location With Name : ");
                //Format :- C:\Users\nirashuk\source\repos\WeatherReport\Weather\FileReaderApplication\InputFile\Cities.json
                string inputPath = Console.ReadLine();

                CityInput cityInput = new CityInput();

                using (StreamReader r = new StreamReader(inputPath))
                {
                    string jsonFile = r.ReadToEnd();
                    cityInput = JsonConvert.DeserializeObject<CityInput>(jsonFile);
                }
                var result = weather.PostAsync(cityInput).GetAwaiter().GetResult();

                Console.WriteLine("Enter Output Destination : ");
                //Format:- C:\Users\nirashuk\source\repos\WeatherReport\Weather\FileReaderApplication\OutputFile\
                string outputPath = Console.ReadLine();

                //Save received Output with city name and timestamp
                foreach (var weatherReport in result)
                {
                    string serializedReport = JsonConvert.SerializeObject(weatherReport);
                    File.WriteAllText(outputPath + weatherReport.name + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmm") + ".json", serializedReport);
                    Console.WriteLine("Weather report " + weatherReport.name + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmm") + ".json" + " created successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
