using GetAir.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using GetAir.JSON;
using System.Web;
using Newtonsoft.Json;
using GetAir.IO;

namespace GetAir
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = @"{""name"":""AirThingsCalibratedData"",""columns"":[""time"",""CO"",""HUMIDITY"",""NO2"",""O3"",""PM10"",""PM2"",""PRESSURE"",""SO2"",""TEMP""],""values"":[""2020-01-10T09:00:00Z"",1.2229588296440941,55.414599999999993,73.9002517059506,14.136845902111464,129.138192,63.008696799999996,961.8864,20.717822193709519,3.17]}";
            Main_JSON sample = JsonConvert.DeserializeObject<Main_JSON>(test);

            GetAirData();

            
        }

        private static void GetAirData()
        {

            //Console.WriteLine("starting");
            List<Station> stations = IO.ReadData.GetStations();

            for (int i = 0; i < stations.Count; i++)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(stations[i].Url);
                req.Timeout = Constants.request_timeout;
                try
                {
                    using (WebResponse res = (HttpWebResponse)req.GetResponse())
                    {
                        Stream s = res.GetResponseStream();
                        StreamReader sr = new StreamReader(s);
                        string result = sr.ReadToEnd();

                        //sample result at this point
                        //{"name":"AirThingsCalibratedData","columns":["time","CO","HUMIDITY","NO2","O3","PM10","PM2","PRESSURE","SO2","TEMP"],"values":[["2020-01-10T09:00:00Z",1.2229588296440941,55.414599999999993,73.9002517059506,14.136845902111464,129.138192,63.008696799999996,961.8864,20.717822193709519,3.17]]}

                        result = result.Replace("[[", "[");
                        result = result.Replace("]]", "]");

                        Main_JSON station_data = JsonConvert.DeserializeObject<Main_JSON>(result);
                        Measurement m = Transformer.ConvertArraysToMeasurement(station_data);
                        m.Station_id = stations[i].Id;

                        string err_message = string.Empty;
                        int insert_result = InsertData.InsertMeasurement(m, ref err_message);
                        if (insert_result != 1)
                        {
                            //insert in err log table.
                            //err_message holds the err value if any.
                            string insertion_error_message = string.Empty;
                            InsertData.InsertError(err_message, result, ref insertion_error_message);
                        }


                    }
                }
                catch (Exception err_msg)
                {
                    Console.WriteLine(err_msg);
                    //Console.ReadLine();
                }
            }

        }
    }
}
