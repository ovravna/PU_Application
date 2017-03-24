using System;
using System.Collections.Generic;
using System.Text;
using PU_Application.Droid.Data;
using PU_Application.Helpers;
using PU_Application.Model;

namespace PU_Application.Data
{
    class EventParser
    {

        public static ObservableRangeCollection<Item> Parse() {
            var items = IcalParser.Parse();
            var lectures = HtmlReader.GetLectures();
            

            foreach (var item in items) {
                var idNum = item.Id.Split('-')[1];
                item.Lecture = lectures[idNum];
                item.MazeUrl = item.Lecture.mazeUrl;
				item.Time = item.Lecture.tid;
				item.Day = item.Lecture.day;
				item.Room = item.Lecture.rom;
            }


            return items;


        }


    }
}
