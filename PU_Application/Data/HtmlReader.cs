using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;


namespace PU_Application.Droid.Data
{
    public class HtmlReader
    {
        static string url = "https://ntnu.1024.no/2017/spring/ravna";
        static string[] days = {"mandag", "tirsdag", "onsdag", "torsdag", "fredag"};


        public static Dictionary<string, Lecture> GetLectures() {
            var lectures = new Dictionary<string, Lecture>();

            var document = new HtmlDocument();
//            var downloader = new HttpDownloader(url, null, null); 

            string htmlString = new WebClient().DownloadString(url);
           
            document.LoadHtml(htmlString);
            var node = document.DocumentNode
                .ChildNodes["html"].ChildNodes["body"];

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

            foreach (var tuple in oddEvenList) {

                foreach (var tr in new [] {tuple.Item1, tuple.Item2}) {
                    var tbl = tr.ChildNodes.Where(n => n.Name != "#text");
                    foreach (var child in tbl)
                    {
                        if (!child.HasAttributes)
                            continue;

                        var classAttribute = child.Attributes["class"].Value;

                        if (classAttribute.Contains("time"))
                            continue;

                        if (classAttribute.Contains("lecture"))
                        {
                            var lecture = GetLecture(child, day);
                            lectures.Add(lecture.id, lecture);
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
                    if (tr.Attributes["class"].Value.Contains("odd"))
                        day = 0;
                }
            }

            return lectures;
        }

        private static Lecture GetLecture(HtmlNode node, int day) {
            var name = node.Attributes["title"].Value;
            var id = node.Attributes["class"].Value.Split(' ').First(n => n.StartsWith("lecture-")).Replace("lecture-", "");

            var children = node.ChildNodes
                .Where(n => n.HasAttributes)
                .First(n => n.Attributes["class"].Value == "wrapper")
                .ChildNodes
                .Where(n => n.HasAttributes);

            var room = children.First(n => n.Attributes["class"].Value == "room");
            var roomNode = room.ChildNodes.First(n => n.Name == "a");
            var mazeUrl = roomNode.Attributes["href"].Value;
            mazeUrl = Regex.Replace(mazeUrl, "(.*?.com/)(\\?.*)", n => $"{n.Groups[1]}embed.html{n.Groups[2]}");
            mazeUrl = WebUtility.HtmlDecode(mazeUrl);

            var roomName = roomNode.InnerText;
            var type = children.First(n => n.Attributes["class"].Value == "type").InnerText;

            var time = name.Substring(name.Length - 11);

            name = name.Substring(0, name.Length - 11);



            return new Lecture {
                id = id,
                navn = name,
                tid = time,
                mazeUrl = mazeUrl,
                rom = roomName,
                type = type,
                day = days[day]
            };

        }

    }

    public struct Lecture {
        public string id;
        public string navn;
        public string tid;
        public string rom;
        public string mazeUrl;
        public string type;
        public string day;

    }

}
