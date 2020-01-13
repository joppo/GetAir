using System;
using System.Collections.Generic;
using System.Text;

namespace GetAir.IO
{
    class Queries
    {
        #region Queries
        public static string q_GetStations = "SELECT Id, Name, url ,DisplayName, Description FROM Stations";
        public static string q_InsertMeasurements = "INSERT INTO[dbo].[Measurements] ([Time], [CO], [Humidity], [NO2], [O3], [PM10], [PM2], [Pressure], [SO2], [Temperature], [Station_id]) VALUES(@Time, @CO, @Humidity, @NO2, @O3, @PM10, @PM2, @Pressure, @SO2, @Temperature, @Station_id)";
        public static string q_InsertErrorMessages = "INSERT INTO[dbo].[Error_Log] ([DateTime], [Error_Message], [Raw_Data]) VALUES(@DateTime, @Error_Message, @Raw_Data)";
        #endregion

        #region Settings
        public const string SPSqlDateFormat = "yyyy/MM/dd HH:mm:ss";
        #endregion

        #region Parameters
        public static string p_Time = "@Time";
        public static string p_CO = "@CO";
        public static string p_Humidity = "@Humidity";
        public static string p_NO2 = "@NO2";
        public static string p_O3 = "@O3";
        public static string p_PM10 = "@PM10";
        public static string p_PM2 = "@PM2";
        public static string p_Pressure = "@Pressure";
        public static string p_SO2 = "@SO2";
        public static string p_Temperature = "@Temperature";
        public static string p_Station_Id = "@Station_Id";

        public static string p_DateTime = "@DateTime";
        public static string p_Error_Message = "@Error_Message";
        public static string p_Raw_Data = "@Raw_Data";


        #endregion
    }
}
