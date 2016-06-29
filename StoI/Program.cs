using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StoI.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoI
{
    class Program
    {
        static string fileName = @"C:\Users\henri\OneDrive\Golden Cheetah\Henrik\activities\2016_06_27_15_50_16.json";
        static string segmentsFile = @"E:\_pen32gb\src\GoldenCheetahTool\StoI\Json\segments.json";

        static StravaSegments segments;

        static void Main(string[] args)
        {
            LoadSegments();
            LoadGoldenCheeath();
            //LoadJson();
        }

        private static void LoadSegments()
        {
            segments = JsonConvert.DeserializeObject<StravaSegments>(File.ReadAllText(segmentsFile));
        }

        private static void LoadGoldenCheeath()
        {
            // read file into a string and deserialize JSON to a type
            GoldenCheeath.Rootobject ride1 = JsonConvert.DeserializeObject<GoldenCheeath.Rootobject>(File.ReadAllText(fileName));

            var lat = ride1.RIDE.SAMPLES[0].LAT;
            var lon = ride1.RIDE.SAMPLES[0].LON;

            CleanObviousInvalidSlope(ride1);
            AddChangedNote(ride1);

            WriteJson(ride1);
        }

        private static void AddChangedNote(GoldenCheeath.Rootobject ride1)
        {
            ride1.RIDE.TAGS.ChangeHistory += ".";
        }

        private static void CleanObviousInvalidSlope(GoldenCheeath.Rootobject ride1)
        {
            double SLOPEISFLAT = 0.001;
            var flatList = Array.FindAll(ride1.RIDE.SAMPLES, e => Math.Abs(e.SLOPE) < SLOPEISFLAT).ToList();
            flatList.ForEach(c => c.SLOPE = 0);
        }

        private static void WriteJson(GoldenCheeath.Rootobject ride1)
        {
            // http://stackoverflow.com/questions/6507889/how-to-ignore-a-property-in-class-if-null-using-json-net
            var json = JsonConvert.SerializeObject(ride1,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });

            string jsonFormatted = JValue.Parse(json).ToString();

            // Known issue: values like ""SLOPE":3.44613e-14" will be saved as ""SLOPE":3.44613E-14", and then clipped (track shorten) when re-loaded in Golden Cheetah
            File.WriteAllText(fileName, jsonFormatted);
        }
    }
}
