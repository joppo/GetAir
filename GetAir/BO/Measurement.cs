using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace GetAir.BO
{
    public class Measurement
    {
        public object this[string propertyName]
        {
            get
            {
                Type measureType = typeof(Measurement);
                PropertyInfo propInfo = measureType.GetProperty(propertyName);
                return propInfo.GetValue(this, null);
            }
            set
            {
                Type measureType = typeof(Measurement);
                PropertyInfo propInfo = measureType.GetProperty(propertyName);
                propInfo.SetValue(this, value, null);
            }
        }

        //capitalization of this class' properties is screwed thanks to the geniuses who created the JSON
        public DateTime Time { get; set; }
        public float CO { get; set; }
        public float Humidity { get; set; }
        public float NO2 { get; set; }
        public float O3 { get; set; }
        public float PM10 { get; set; }
        public float PM2 { get; set; }
        public float Pressure { get; set; }
        public float SO2 { get; set; }
        public float Temperature { get; set; }
        public int Station_id { get; set; }
    }
}
