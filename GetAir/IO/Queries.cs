using System;
using System.Collections.Generic;
using System.Text;

namespace GetAir.IO
{
    class Queries
    {
        public static string q_GetStations = "SELECT Id, Name, url ,DisplayName, Description FROM Stations";
        public static string q_InsertMeasurements = "INSERT INTO[dbo].[Measurements] ([Time], [CO], [Humidity], [NO2], [O3], [PM10], [PM2], [Pressure], [SO2], [Temperature], [Station_id]) VALUES(@Time, @CO, @Humidity, @NO2, @O3, @MP10, @PM2, @Pressure, @SO2, @Temperature, @Station_id)";

        #region Parameters
        public static string p_Time = "@Time";
        public static string p_CO = "@CO";
        public static string p_Humidity = "@Humidity";
        public static string NO2 = "@NO2";
        public static string O3 = "@O3";
        public static string MP10 = "@MP10";
        public static string MP2 = "@MP2";
        public static string Pressure = "@Pressure";
        public static string SO2 = "@SO2";


        #endregion
    }
}
