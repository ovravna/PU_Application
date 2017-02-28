using System;
using System.Diagnostics;
using System.Text;
using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;
using Environment = Android.OS.Environment;

namespace PU_Application.Droid.Data
{
    public class IcalParser
    {

        public static void Parse() {
            IICalendarCollection calendars;
            var path = @"/sdcard/Download/cal.ics";

//            Downloader.Download(path);
            calendars = Calendar.LoadFromFile(path);


//            try
//            {
//                calendars = Calendar.LoadFromFile(path);
//                
//            }
//            catch (Exception e) {
//                Downloader.Download(path);
//                calendars = Calendar.LoadFromFile(path);
//            }







            //            IICalendarCollection calendars = ICalendar.LoadFromFile(@"Business.ics");

            var occurrences = calendars.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(1));

            foreach (Occurrence occurrence in occurrences)
            {
//                DateTime occurrenceTime = occurrence.Period.StartTime.Local;
                IRecurringComponent rc = occurrence.Source as IRecurringComponent;
                if (rc != null)
                    Console.WriteLine($"Kake! {rc.Summary} {rc.Start} : {rc.Description} : {rc}");
            }


        }


    }
}
