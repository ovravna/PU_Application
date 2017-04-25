using PU_Application.Droid.Data;
using PU_Application.Helpers;
using PU_Application.Model;

namespace PU_Application.Data
{
	public static class EventParser
	{
		public static ObservableRangeCollection<Item> Parse(string username)
		{
			var items = IcalParser.Parse(username);
			var lectures = HtmlReader.GetLectures(username);
			
			foreach (var item in items) {
				var idNum = item.Id.Split('-')[1];
				item.Lecture = lectures[idNum];
				item.MazeUrl = item.Lecture.mazeUrl.Replace("&amp;", "&") + "&newtablink=false";
				item.Time = item.Lecture.tid;
				item.Day = item.Lecture.day;
				item.Room = item.Lecture.rom;
			}

			return items;
		}
	}
}