using PU_Application.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ical.Net.DataTypes;
using System.Threading.Tasks;
using PU_Application.Droid.Data;
using System;
using Ical.Net.Interfaces.DataTypes;

namespace PU_Application.Model
{
    public class Item : BaseDataObject
    {
        public Item() : base()
        { 
        }

        string mazeUrl = string.Empty;
		IDateTime date;
        Lecture lecture;
		String time;
		String day;
		String rom;

        public Lecture Lecture
        {
            get { return lecture; }
            set { SetProperty(ref lecture, value); }
        } 

        public string MazeUrl
        {
            get { return mazeUrl; }
            set { SetProperty(ref mazeUrl, value); }
        }

		public string Time
		{
			get { return time; }
			set { SetProperty(ref time, value); }
		}

		public string Room
		{
			get { return rom; }
			set { SetProperty(ref rom, value); }
		}

		public string Day
		{
			get { return day; }
			set { SetProperty(ref day, value); }
		}

		public IDateTime Date
		{
			get { return date; }
			set { SetProperty(ref date, value); }
		}
        /// <summary>
        /// Private backing field to hold the text
        /// </summary>
        string text = string.Empty;
        /// <summary>
        /// Public property to set and get the text of the item
        /// </summary>
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

    }
}
