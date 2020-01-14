using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace GetAir.JSON
{
    class JSON_Skeleton
    {
    }
    public class Main_JSON
    {
        public string name { get; set; }
        public IList<string> columns { get; set; }
        public IList<string> values { get; set; }
    }

    public class ColumnNames
    {
        public static string time = "time";
        public static string CO = "CO";
        public static string HUMIDITY = "HUMIDITY";
        public static string NO2 = "NO2";
        public static string O3 = "O3";
        public static string PM10 = "PM10";
        public static string PM2 = "PM2";
        public static string PRESSURE = "PRESSURE";
        public static string SO2 = "SO2";
        public static string TEMP = "TEMP";
    }
    public class JSONMeasurement
    {
        public object this[string propertyName]
        {
            get
            {
                Type measureType = typeof(JSONMeasurement);
                PropertyInfo propInfo = measureType.GetProperty(propertyName);
                return propInfo.GetValue(this, null);
            }
            set
            {
                Type measureType = typeof(JSONMeasurement);
                PropertyInfo propInfo = measureType.GetProperty(propertyName);
                propInfo.SetValue(this, value, null);
            }
        }

        //capitalization of this class' properties is screwed thanks to the geniuses who created the JSON
        public string time { get; set; }
        public string CO { get; set; }
        public string HUMIDITY { get; set; }
        public string NO2 { get; set; }
        public string O3 { get; set; }
        public string PM10 { get; set; }
        public string PM2 { get; set; }
        public string PRESSURE { get; set; }
        public string SO2 { get; set; }
        public string TEMP { get; set; }
        public int Station_id { get; set; }
    }
}
