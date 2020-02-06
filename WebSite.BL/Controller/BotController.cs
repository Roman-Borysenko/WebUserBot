using System;
using System.Collections.Generic;

namespace WebSite.BL.Controller
{
    class BotController
    {
        private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";
        private const string Referer = "https://www.google.com/";
        private string address;
        private List<string> proxy;
        private List<string> userAgent;
        private List<string> referer;
        private int numberThreads;
        private int timeMin;
        private int timeMax;
        private bool followingLinks;


        public string Address { get { return address; }  
            set 
            {
                if(value.IsUrl())
                {
                    address = value;
                } else
                {
                    throw new ArgumentException("The variable is not a URL.", nameof(address));
                }
            } 
        }
        public List<string> Proxy 
        {
            get { return proxy; }
            set { proxy = value.IsListIPAddress(); }
        }
        public List<string> UserAgents 
        { 
            get { return userAgent; } 
            set { userAgent = value.IsStringList(); }
        }
        public List<string> Referers 
        { 
            get { return referer; } 
            set { referer = value.IsListUrl(); }
        }
        public int NumberThreads 
        {
            get { return numberThreads; } 
            set 
            {
                if (value < 1 || value > 10000)
                {
                    throw new ArgumentOutOfRangeException("The argument does not match a range of 1 to 10,000.", nameof(numberThreads));
                }
                numberThreads = value;
            }
        }
        public int TimeMin
        {
            get { return timeMin; }
            set
            {
                if (value < 1 || value > 300)
                {
                    throw new ArgumentOutOfRangeException("The argument does not match a range of 1 to 300.", nameof(timeMin));
                }
                timeMin = value;
            }
        }
        public int TimeMax
        {
            get { return timeMax; }
            set
            {
                if (value < 1 || value > 300 || value > TimeMax)
                {
                    throw new ArgumentOutOfRangeException("The argument does not match a range of 1 to 300.", nameof(timeMax));
                }
                timeMax = value;
            }
        }
        public bool FollowingLinks { get; set; }

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
            var bot = new Web();
        }
    }
}
