using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoI.Json
{
    class StravaSegments
    {
        public List<Segment> segments { get; set; }

        public class Segment
        {
            public string name { get; set; }
            public string description { get; set; }
            public int stravaID { get; set; }
            public double latStart { get; set; }
            public double lonStart { get; set; }
            public double latEnd { get; set; }
            public double lonEnd { get; set; }
        }
    }
}
