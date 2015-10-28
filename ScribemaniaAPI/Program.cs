using Microsoft.Owin.Hosting;
using System;

namespace ScribemaniaAPI
{
    /// <summary>
    /// For use when running self hosted.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:4000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Listening at " + baseAddress);
                Console.ReadLine();
            }

        }
    }
}