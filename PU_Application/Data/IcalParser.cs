using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ical.Net.DataTypes;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;
using Syncfusion.Windows.Controls;
using Calendar = Ical.Net.Calendar;

namespace Analyze_2017.backend.telemetry
{
    public class IcalParser
    {

        public static void Parse() {
//                        var calendars = Calendar.LoadFromFile(@"C:\Users\Ole\Source\Repos\RevolveAnalyze2017\Revolve Analyze\Analyze 2017\res\cal.ics");

//            IICalendarCollection calendars = ICalendar.LoadFromFile(@"Business.ics");

            var occurrences = calendars.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(1));

            foreach (Occurrence occurrence in occurrences)
            {
//                DateTime occurrenceTime = occurrence.Period.StartTime.Local;
                IRecurringComponent rc = occurrence.Source as IRecurringComponent;
                if (rc != null)
                    Console.WriteLine($"{rc.Summary} {rc.Start} : {rc.Description} : {rc}");
            }


        }


    }
}
