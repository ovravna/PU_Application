using System;
using System.Collections.Generic;
using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;
using PU_Application.Helpers;
using PU_Application.Model;
using System.Linq;

namespace PU_Application.Droid.Data
{
    public class IcalParser
    {

        public static ObservableRangeCollection<Item> Parse() {
            IICalendarCollection calendars;
            var path = @"/sdcard/Download/cal.ics";

//            Downloader.Download(path);
//            calendars = Calendar.LoadFromFile(path);


            try
            {
                calendars = Calendar.LoadFromFile(path);
                
            }
            catch (Exception e) {
                Downloader.Download(path);
                calendars = Calendar.LoadFromFile(path);
            }







            //            IICalendarCollection calendars = ICalendar.LoadFromFile(@"Business.ics");

            var occurrences = calendars.GetOccurrences(DateTime.Now, DateTime.Today.AddDays(7));
            

            var range = new ObservableRangeCollection<Item>();
            
            var occ = occurrences.ToList();
            occ.Sort((n, m) => n.Source.Start.CompareTo(m.Source.Start));
            

            foreach (Occurrence occurrence in occ)
            {
                range.Add(ToItem(occurrence));
            }
           

            return range;
        }

        private static Item ToItem(Occurrence occurrence) {
            var rc = occurrence.Source as IRecurringComponent;

            if (rc == null) {
                return null;
            }


            var item = new Item {
                Description = rc.Start.AsSystemLocal.ToLongDateString(),
                Text = rc.Description,
                Id = rc.Uid,
            };

            return item;
        }


    }
}
