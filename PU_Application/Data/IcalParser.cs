using System;
using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;
using PU_Application.Helpers;
using PU_Application.Model;

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

            var occurrences = calendars.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(3));

            var range = new ObservableRangeCollection<Item>();


            foreach (Occurrence occurrence in occurrences)
            {

                range.Add(ToItem(occurrence));


//                DateTime occurrenceTime = occurrence.Period.StartTime.Local;
//                IRecurringComponent rc = occurrence.Source as IRecurringComponent;
//                if (rc != null)
//                    Console.WriteLine($"Kake! {rc.Summary} {rc.Start} : {rc.Description} : {rc}");
            }


            return range;
        }

        private static Item ToItem(Occurrence occurrence) {
            var rc = occurrence.Source as IRecurringComponent;

            if (rc == null) {
                return null;
            }


            var item = new Item {
                Description = rc.Description,
                Text = rc.Summary,
                Id = rc.Uid,
            };

            return item;
        }


    }
}
