using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GetAir.JSON;

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

        public static Measurement ConvertJSONToMeasurement(Main_JSON generic)
        {
            Measurement mm = new Measurement();
            mm.Time = DateTime.Parse(generic.values[0]);
            mm.CO = float.Parse(generic.values[1]);
            mm.Humidity = float.Parse(generic.values[2]);
            mm.NO2 = float.Parse(generic.values[3]);
            mm.O3 = float.Parse(generic.values[4]);
            mm.PM10 = float.Parse(generic.values[5]);
            mm.PM2 = float.Parse(generic.values[6]);
            mm.Pressure = float.Parse(generic.values[7]);
            mm.SO2 = float.Parse(generic.values[8]);
            mm.Temperature = float.Parse(generic.values[9]);

            return mm;
        }
    }
}
