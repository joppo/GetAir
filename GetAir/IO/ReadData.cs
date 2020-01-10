using System;
using System.Collections.Generic;
using System.Text;
using GetAir.BO;
using System.Data;
using System.Data.SqlClient;

namespace GetAir.IO
{
    class ReadData
    {
        public static List<Station> GetStations()
        {
            List<Station> stations = new List<Station>();
            using (SqlConnection c = new SqlConnection(Settings.connString))
            {
                SqlCommand cmd = new SqlCommand(Queries.q_GetStations, c);
                c.Open();
                SqlDataAdapter a = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                a.Fill(dt);
                stations = Transformer.ConvertDTtoStations(dt);
            }
            return stations;
        }
    }

    //public List<UserResult> GetUserResults(string dateFilter, int course_Id)
    //{
    //    List<UserResult> q = new List<UserResult>();
    //    using (SqlConnection c = new SqlConnection(Common.Utils.GetConnectionString()))
    //    {
    //        SqlCommand cmd;
    //        cmd = new SqlCommand(Constants.qry_GetUsersAndPoints, c);
    //        SqlParameter p_course_id = cmd.Parameters.Add(Constants.p_Course_Id, SqlDbType.Int);
    //        p_course_id.Value = course_Id;
    //        SqlParameter p_dateFilter = cmd.Parameters.Add(Constants.p_DateFilter, SqlDbType.NVarChar);
    //        p_dateFilter.Value = dateFilter;

    //        c.Open();
    //        SqlDataAdapter a = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        a.Fill(dt);
    //        q = map.ConvertDTToUserResults(dt);
    //    }
    //    return q;
    //}
}
