using System.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using WebSite.BL;

namespace WebSite
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 8;
            if (value < 1 || value > 300)
            {
                throw new ArgumentOutOfRangeException("The argument does not match a range of 1 to 300.");
            } else
            {
                Console.WriteLine("OK");
            }
            //Console.WriteLine(ConfigurationManager.AppSettings["Address"]);
            //var proxy = new List<string> { "51.158.123.35:8811", "51.158.123.35:8822", "51.158.123.35:8833" };
            //var proxy = new List<string> { "https://www.youtube.com/", "https://www.google.com/", "https://www.facebook.com/", "https://midasstone.com.ua/prirodnyy-kamen/plitka-iz-kamnya" };
            //if (proxy.IsListUrl() == null)
            //{
            //    Console.WriteLine("null");
            //}
            //else
            //{
            //    foreach (var item in proxy)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            Console.ReadLine();
        }
    }
}