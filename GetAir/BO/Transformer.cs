using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GetAir.BO
{
    class Transformer
    {
        public static List<Station> ConvertDTtoStations(DataTable dt)
        {
            List<Station> stations = new List<Station>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Station s = new Station();

                try
                {
                    string id_str = dt.Rows[i]["Id"].ToString();
                    int id = int.Parse(id_str);
                    s.Id = id;
                }
                catch (ArgumentException)
                {
                    s.Id = -1;
                }

                s.Name = dt.Rows[i]["Name"].ToString();
                s.DisplayName = dt.Rows[i]["DisplayName"].ToString();
                s.Description = dt.Rows[i]["Description"].ToString();
                s.Url = dt.Rows[i]["url"].ToString();

                stations.Add(s);
            }

            return stations;
        }
    }
}
