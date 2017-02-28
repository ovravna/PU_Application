using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace Analyze_2017.backend.telemetry
{
    public class HtmlReader
    {
        static string url = "https://ntnu.1024.no/2017/spring/ravna";
        static string[] days = {"mandag", "tirsdag", "onsdag", "torsdag", "fredag"};


        public static void Run() {
            var document = new HtmlDocument();
//            var downloader = new HttpDownloader(url, null, null);

            string htmlString = new WebClient().DownloadString(url);
            document.LoadHtml(htmlString);
            var node = document.DocumentNode.
                .SelectNodes("html").FindFirst("body");

            var bd = node.ChildNodes.First(n => n.Id == "bd");
            var schedule = bd.ChildNodes["table"];
            var table = schedule.ChildNodes["tbody"];

            var filteredTable = table.ChildNodes
                .Where(n => n.Name != "#text").ToList();

            var oddEvenList = new List<Tuple<HtmlNode, HtmlNode>>();

            for (var i = 0; i < filteredTable.Count; i += 2) {
                oddEvenList.Add(Tuple.Create(filteredTable[i], filteredTable[i + 1]));
            }

            

            var day = 0;

//            if (filteredTable == null) {
//                Console.WriteLine("kake!");
//                return;
//            }

            foreach (var tuple in oddEvenList) {

                foreach (var tr in new [] {tuple.Item1, tuple.Item2}) {
                    var tbl = tr.ChildNodes.Where(n => n.Name != "#text");
                    foreach (var child in tbl)
                    {

                        if (!child.HasAttributes)
                        {
                            continue;
                        }

                        var classAttribute = child.Attributes["class"].Value;


                        if (classAttribute.Contains("time"))
                        {
                            continue;
                        }

                        if (classAttribute.Contains("lecture"))
                        {
//                            Console.WriteLine($"{child.Attributes["title"].Value} {days[day]}");

                            var l = GetLecture(child, day);

                            Console.WriteLine(l.navn);



                        }

                        if (!classAttribute.Contains("last")) continue;
                        if (tr.Attributes["class"].Value.Contains("even"))
                        {
                            if (!classAttribute.Contains("lecture")) {
                                continue;

                            }
                        }
                        day++;
                    }
                    if (tr.Attributes["class"].Value.Contains("odd")) {
                        day = 0;
                    }
                }


            }
        }

        private static Lecture GetLecture(HtmlNode node, int day) {
            var name = node.Attributes["title"].Value;
            var children = node.ChildNodes
                .Where(n => n.HasAttributes)
                .First(n => n.Attributes["class"].Value == "wrapper")
                .ChildNodes
                .Where(n => n.HasAttributes);
            var room = children.First(n => n.Attributes["class"].Value == "room");
            var mazeUrl = room.ChildNodes.First(n => n.Name == "a").Attributes["href"].Value;
            var roomName = room.FirstChild.InnerText;
            var type = children.First(n => n.Attributes["class"].Value == "type").InnerText;

            var time = name.Substring(name.Length - 11);

            name = name.Substring(0, name.Length - 11);



            return new Lecture {
                navn = name,
                tid = time,
                mazeUrl = mazeUrl,
                rom = roomName,
                type = type,
                day = days[day]
            };

        }

    }

    struct Lecture {
        public string navn;
        public string tid;
        public string rom;
        public string mazeUrl;
        public string type;
        public string day;

    }

}
