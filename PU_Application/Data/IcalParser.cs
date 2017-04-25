using System;
using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Interfaces.Components;
using PU_Application.Helpers;
using PU_Application.Model;
using System.Linq;
using System.IO;

namespace PU_Application.Droid.Data
{
    public static class IcalParser
    {
        public static ObservableRangeCollection<Item> Parse(string username)
        {
            var icalText = Ntnu1024.GetCalendar(username);
            var calendars = Calendar.LoadFromStream(new StringReader(icalText));

            var occurrences = calendars
                .GetOccurrences(DateTime.Now.AddDays(-1), DateTime.Today.AddDays(7))
                .OrderBy(o => o.Source.Start)
                .Select(ToItem);
            
            return new ObservableRangeCollection<Item>(occurrences);
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
				Date = rc.Start,
            };

            return item;
        }
    }
}