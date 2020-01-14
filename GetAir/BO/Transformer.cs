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

        public static Measurement ConvertArraysToMeasurement(Main_JSON d)
        {
            JSONMeasurement jm = new JSONMeasurement();
            Measurement mm = new Measurement();

            for (int i = 0; i < d.columns.Count; i++)
            {
                jm[d.columns[i]] = d.values[i];
            }

            mm.Time = (jm.time == null) ? DateTime.MinValue : DateTime.Parse(jm.time);
            mm.CO = (jm.CO == null) ? 0 : float.Parse(jm.CO);
            mm.Humidity = (jm.HUMIDITY == null) ? 0 : float.Parse(jm.HUMIDITY);
            mm.NO2 = (jm.NO2 == null) ? 0 : float.Parse(jm.NO2);
            mm.O3 = (jm.O3 == null) ? 0 : float.Parse(jm.O3);
            mm.PM10 = (jm.PM10 == null) ? 0 : float.Parse(jm.PM10);
            mm.PM2 = (jm.PM2 == null) ? 0 : float.Parse(jm.PM2);
            mm.Pressure = (jm.PRESSURE == null) ? 0 : float.Parse(jm.PRESSURE);
            mm.SO2 = (jm.SO2 == null) ? 0 : float.Parse(jm.SO2);
            mm.Temperature = (jm.TEMP == null) ? 0 : float.Parse(jm.TEMP);

            return mm;
        }
    }
}
