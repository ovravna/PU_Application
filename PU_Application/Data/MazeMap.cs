using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace PU_Application.Droid.Data
{
    class MazeMap
    {
        static readonly WebClient WebClient = new WebClient();


        public static void GetJson(string url) {
            var json = WebClient.DownloadString(url);

            var k = JObject.Parse(json);

            Console.WriteLine(k["pois"]);

        }







    }
}
