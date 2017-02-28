using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Android.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PU_Application.Data
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
