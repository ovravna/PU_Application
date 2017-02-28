using System;
using System.IO;
using System.Linq;k
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Analyze_2017.backend.telemetry
{
    public class JsonReader
    {

        static string BaseUrl = "http://use.mazemap.com/?campusid=1&desttype=identifier&dest={0}";
        public static readonly string absloutePath = Regex.Replace(Environment.CurrentDirectory, "(?<=Analyze 2017).*", "");
        public void Run()
        {
            var url = "http://api.mazemap.com/api/pois/?campusid=1&srid=4326";

            //            var web = new WebClient();
            //            var json = web.DownloadString(url);
//            File.WriteAllText(Tools.pathTo(@"\res\json.txt"), json);


            var json = File.ReadAllText(absloutePath + @"\res\json.txt");

            var k = JObject.Parse(json);

            var room = "R7";


            var id = k["pois"]
                .First(n => n["title"].ToString() == room)["identifier"].ToString();



//                .Select(n => n["identifier"].ToString());
                
//                .ForEachDo(Console.WriteLine);

            Console.WriteLine(BaseUrl, id);



        }
    }
}
