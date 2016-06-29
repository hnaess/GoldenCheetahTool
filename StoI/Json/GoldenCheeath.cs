using Newtonsoft.Json;

namespace StoI
{
    class GoldenCheeath
    {
        // https://github.com/GoldenCheetah/GoldenCheetah/blob/master/contrib/RideLogger/src/com/ridelogger/formats/JsonFormat.java

        public class Rootobject
        {
            public RIDE RIDE { get; set; }
        }

        public class RIDE
        {
            public string STARTTIME { get; set; }
            public int RECINTSECS { get; set; }
            public string DEVICETYPE { get; set; }
            public string IDENTIFIER { get; set; }
            public TAGS TAGS { get; set; }
            public INTERVAL[] INTERVALS { get; set; }
            public SAMPLE[] SAMPLES { get; set; }
        }

        /// <summary>
        /// Note complete
        /// </summary>
        public class TAGS
        {
            public string Athlete { get; set; }
            [JsonProperty("Change History")]
            public string ChangeHistory { get; set; }
            public string Data { get; set; }
            public string Device { get; set; }
            public string DeviceInfo { get; set; }
            [JsonProperty("File Format")]
            public string FileFormat { get; set; }
            public string Filename { get; set; }
            public string Month { get; set; }
            public string Notes { get; set; }
            public string Objective { get; set; }
            [JsonProperty("Source Filename")]
            public string SourceFilename { get; set; }
            public string Sport { get; set; }
            public string Weekday { get; set; }
            public string WorkoutCode { get; set; }
            public string Year { get; set; }
        }

        public class INTERVAL
        {
            public string NAME { get; set; }
            public int START { get; set; }
            public int STOP { get; set; }
        }

        public class SAMPLE
        {
            public int SECS { get; set; }
            public float KM { get; set; }
            public float WATTS { get; set; }
            public float CAD { get; set; }
            public float KPH { get; set; }
            public float HR { get; set; }
            public float ALT { get; set; }
            //public float LAT { get; set; }
            //public float LON { get; set; }
            public decimal LAT { get; set; }
            public decimal LON { get; set; }
            //public string LAT { get; set; }
            //public string LON { get; set; }
            public float SLOPE { get; set; }
        }
    }
}
