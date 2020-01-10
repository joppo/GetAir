using GetAir.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using GetAir.JSON;
using System.Web;
using Newtonsoft.Json;

namespace GetAir
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = @"{""name"":""AirThingsCalibratedData"",""columns"":[""time"",""CO"",""HUMIDITY"",""NO2"",""O3"",""PM10"",""PM2"",""PRESSURE"",""SO2"",""TEMP""],""values"":[""2020-01-10T09:00:00Z"",1.2229588296440941,55.414599999999993,73.9002517059506,14.136845902111464,129.138192,63.008696799999996,961.8864,20.717822193709519,3.17]}";
            Main_JSON sample = JsonConvert.DeserializeObject<Main_JSON>(test);

            GetAirData();
            Console.WriteLine("Hello World!");
        }

        private static void GetAirData()
        {
            List<Station> stations = IO.ReadData.GetStations();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(stations[0].Url);
            req.Timeout = Constants.request_timeout;
            try
            {
                using (WebResponse res = (HttpWebResponse)req.GetResponse())
                {
                    Stream s = res.GetResponseStream();
                    StreamReader sr = new StreamReader(s);
                    string result = sr.ReadToEnd();
                    
                    result = result.Replace("[[", "[");
                    result = result.Replace("]]", "]");

                    Main_JSON station_data = JsonConvert.DeserializeObject<Main_JSON>(result);
                    
                }
            } catch(Exception eeeeeeeeeeeeeeee)
            {
                
            }

        }
    }
}
