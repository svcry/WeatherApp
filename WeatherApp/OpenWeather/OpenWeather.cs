using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WeatherApp.OpenWeather
{
    internal class OpenWeather
    {
        public Coord coord;

        public Weather[] weather;

        [JsonProperty("base")]
        public string Base;

        public Main main;

        public double visiblity;

        public Wind wind;

        public Clouds clouds;

        public double dt;

        public Sys sys;

        public double timezone;

        public int id;

        public string name;

        public double cod;
    }
}
