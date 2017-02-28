using System.Net;

namespace Analyze_2017.backend.telemetry
{
    public class Downloader
    {

        public static void Download() {

            var url = "https://ntnu.1024.no/2017/spring/ravna/ical/";

            var path = @"C:\Users\Ole\Source\Repos\RevolveAnalyze2017\Revolve Analyze\Analyze 2017\res\cal.ics";

            var myWebClient = new WebClient();

            myWebClient.DownloadFile(url, path);


        }


    }
}
