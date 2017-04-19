using System.Net;

namespace PU_Application.Droid.Data
{
    public static class Ntnu1024
    {
        public static string GetCalendar(string username) {

            return new WebClient().DownloadString($"https://ntnu.1024.no/2017/spring/{username}/ical/");
        }
    }
}