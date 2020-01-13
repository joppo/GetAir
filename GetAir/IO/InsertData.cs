using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GetAir.BO;

namespace GetAir.IO
{
    public class InsertData
    {

        public static int InsertError(string error_m, string raw_data,ref string insertion_error_message)
        {
            int result = -1;
            using (SqlConnection c = new SqlConnection(Settings.connString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Queries.q_InsertErrorMessages, c);
                    SqlParameter p_DateTime = cmd.Parameters.Add(Queries.p_DateTime, SqlDbType.DateTime);
                    p_DateTime.Value = DateTime.Now.ToString(Queries.SPSqlDateFormat);

                    SqlParameter p_Error_Message = cmd.Parameters.Add(Queries.p_Error_Message, SqlDbType.NVarChar);
                    p_Error_Message.Value = error_m;

                    SqlParameter p_Raw_Data = cmd.Parameters.Add(Queries.p_Raw_Data, SqlDbType.NVarChar);
                    p_Raw_Data.Value = raw_data;
                    
                    c.Open();
                    result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    insertion_error_message = ex.Message;
                    return -1;
                }
            }
        }
        public static int InsertMeasurement(Measurement m, ref string err_message)
        {
            int result = -1;
            using (SqlConnection c = new SqlConnection(Settings.connString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Queries.q_InsertMeasurements, c);
                    SqlParameter p_time = cmd.Parameters.Add(Queries.p_Time, SqlDbType.DateTime);
                    p_time.Value = m.Time.ToString(Queries.SPSqlDateFormat);
                    SqlParameter p_CO = cmd.Parameters.Add(Queries.p_CO, SqlDbType.Float);
                    p_CO.Value = m.CO;
                    SqlParameter p_Humidity = cmd.Parameters.Add(Queries.p_Humidity, SqlDbType.Float);
                    p_Humidity.Value = m.Humidity;
                    SqlParameter p_NO2 = cmd.Parameters.Add(Queries.p_NO2, SqlDbType.Float);
                    p_NO2.Value = m.NO2;
                    SqlParameter p_O3 = cmd.Parameters.Add(Queries.p_O3, SqlDbType.Float);
                    p_O3.Value = m.O3;
                    SqlParameter p_PM10 = cmd.Parameters.Add(Queries.p_PM10, SqlDbType.Float);
                    p_PM10.Value = m.PM10;
                    SqlParameter p_PM2 = cmd.Parameters.Add(Queries.p_PM2, SqlDbType.Float);
                    p_PM2.Value = m.PM2;
                    SqlParameter p_Pressure = cmd.Parameters.Add(Queries.p_Pressure, SqlDbType.Float);
                    p_Pressure.Value = m.Pressure;
                    SqlParameter p_SO2 = cmd.Parameters.Add(Queries.p_SO2, SqlDbType.Float);
                    p_SO2.Value = m.SO2;
                    SqlParameter p_Temperature = cmd.Parameters.Add(Queries.p_Temperature, SqlDbType.Float);
                    p_Temperature.Value = m.Temperature;

                    SqlParameter p_Station_Id = cmd.Parameters.Add(Queries.p_Station_Id, SqlDbType.Int);
                    p_Station_Id.Value = m.Station_id;

                    c.Open();
                    result = cmd.ExecuteNonQuery();
                    return result;
                } catch (Exception ex)
                {
                    err_message = ex.Message;
                    return -1;
                }
            }
        }
    }
}
