using PU_Application.Droid.Data;
using Ical.Net.Interfaces.DataTypes;

namespace PU_Application.Model
{
	public class Item : BaseDataObject
	{
		private string _mazeUrl = string.Empty;
		private IDateTime _date;
		private Lecture _lecture;
		private string _time;
		private string _day;
		private string _rom;
		private string _text = string.Empty;
		private string _description = string.Empty;

		public Lecture Lecture
		{
			get => _lecture;
			set => SetProperty(ref _lecture, value);
		} 

		public string MazeUrl
		{
			get => _mazeUrl;
			set => SetProperty(ref _mazeUrl, value);
		}

		public string Time
		{
			get => _time;
			set => SetProperty(ref _time, value);
		}

		public string Room
		{
			get => _rom;
			set => SetProperty(ref _rom, value);
		}

		public string Day
		{
			get => _day;
			set => SetProperty(ref _day, value);
		}

		public IDateTime Date
		{
			get => _date;
			set => SetProperty(ref _date, value);
		}

		/// <summary>
		/// Public property to set and get the text of the item
		/// </summary>
		public string Text
		{
			get => _text;
			set => SetProperty(ref _text, value);
		}

		public string Description
		{
			get => _description;
			set => SetProperty(ref _description, value);
		}
	}
}