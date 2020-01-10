using System;
using System.Collections.Generic;
using System.Text;

namespace GetAir.BO
{
    public class Measurement
    {
        public DateTime Time { get; set; }
        public float CO { get; set; }
        public float Humidity { get; set; }
        public float NO2 { get; set; }
        public float O3 { get; set; }
        public float PM10 { get; set; }
        public float PM2 { get; set; }
        public float Pressure { get; set; }
        public float S02 { get; set; }
        public float Temperature { get; set; }
    }
}
