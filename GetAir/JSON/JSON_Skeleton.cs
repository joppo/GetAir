using System;
using System.Collections.Generic;
using System.Text;

namespace GetAir.JSON
{
    class JSON_Skeleton
    {
    }
    public class Main_JSON
    {
        public string name { get; set; }
        public IList<string> columns { get; set; }
        public IList<string> values { get; set; }
    }
}
