using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeather
{
    internal class Main
    {

        public double temp;

        private double _pressure;
        public double pressure
        {
            get
            {
                return _pressure;
            }

            set
            {
                _pressure = value / 1.3332239;
            }
        }

        public double humidity;

        public double temp_min;

        public double temp_max;

        public double feels_like;

        public int sea_level;

        public int grnd_level;

    }
}


