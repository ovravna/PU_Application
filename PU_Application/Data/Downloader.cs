using System;
using System.Net;

namespace PU_Application.Droid.Data
{
    public class Downloader
    {

        public static void Download(string path) {

            var url = "https://ntnu.1024.no/2017/spring/ravna/ical/";


            var myWebClient = new WebClient();
            try {
                myWebClient.DownloadFile(url, path);

            }
            catch (Exception ex)
            {
                while (ex != null)
                {
                    Console.WriteLine(ex.Message);
                    ex = ex.InnerException;
                }
            }



        }


    }
}
