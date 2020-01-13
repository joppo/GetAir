using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GetAir.IO
{
    public class InsertData
    {
        public int InsertMeasurement()
        {
            int result = -1;
            using (SqlConnection c = new SqlConnection(Settings.connString))
            {
                SqlCommand cmd = new SqlCommand(Queries.q_InsertMeasurements, c);
                SqlParameter p_time = cmd.Parameters.Add()
            }
        }

        //public int InsertCourse(string c_name)
        //{
        //    int result = -1;
        //    using (SqlConnection c = new SqlConnection(Common.Utils.GetConnectionString()))
        //    {
        //        SqlCommand cmd = new SqlCommand(Constants.ins_Course, c);
        //        SqlParameter p_course_name = cmd.Parameters.Add(Constants.p_Name, SqlDbType.NVarChar);
        //        p_course_name.Value = c_name;

        //        c.Open();
        //        result = cmd.ExecuteNonQuery();
        //    }
        //    return result;
        //}
    }
}
