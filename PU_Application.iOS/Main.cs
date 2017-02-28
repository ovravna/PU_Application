using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Foundation;
using PU_Application.Droid.Data;
using UIKit;

namespace PU_Application.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
//            Console.WriteLine("Ninja!");

            IcalParser.Parse();

            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
