using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Model
{
    public class City
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class CityInput
    {
        public CityInput()
        {
            Cities = new List<City>();
        }
        public List<City> Cities { get; set; }
    }
}
