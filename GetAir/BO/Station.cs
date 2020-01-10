using System;
using System.Collections.Generic;
using System.Text;

namespace GetAir.BO
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
    }
}
