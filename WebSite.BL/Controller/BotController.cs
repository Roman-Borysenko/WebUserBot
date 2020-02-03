using System;
using System.Collections.Generic;

namespace WebSite.BL.Controller
{
    class BotController
    {
        private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";
        private const string Referer = "https://www.google.com/";
        public string Address { get;  set; }
        public List<string> Proxy { get; set; }
        public List<string> UserAgents { get; set; }
        public List<string> Referers { get; set; }
        public int NumberThreads { get; set; }
        public int TimeMin { get; set; }
        public int TimeMax { get; set; }
        public bool FollowingLinks { get; set; }
        public int NumberLinks { get; set; }

        public BotController(string address, List<string> proxy, List<string> userAgents, List<string> referers, int timeMin, int timeMax, bool followingLinks)
        {
            Address = address;
            Proxy = proxy;
            UserAgents = userAgents;
            Referers = referers;
            TimeMin = timeMin;
            TimeMax = timeMax;
            FollowingLinks = followingLinks;
        }
        public void Bot()
        {
            
        }
    }
}
