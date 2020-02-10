using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UserBot.Models
{
    public class Bot
    {
        private string address;
        private ObservableCollection<string> proxy;
        private ObservableCollection<string> userAgent;
        private ObservableCollection<string> referer;
        private int numberThreads;
        private int timeMin;
        private int timeMax;

        public string Address
        {
            get { return address; }
            set
            {
                if (value.IsUrl())
                {
                    address = value;
                }
                else
                {
                    throw new ArgumentException("The variable is not a URL.", nameof(address));
                }
            }
        }
        public ObservableCollection<string> Proxy
        {
            get { return proxy; }
            set { proxy = value.IsListIPAddress(); }
        }
        public ObservableCollection<string> UserAgents
        {
            get { return userAgent; }
            set { userAgent = value.IsStringList(); }
        }
        public ObservableCollection<string> Referers
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
                if (value < 1 || value > 300 || value < TimeMin)
                {
                    throw new Exception("The argument does not match a range of 1 to 300.");
                }
                timeMax = value;
            }
        }
        public bool FollowingLinks { get; set; }

        public Bot(string address)
        {
            Address = address;
        }
        public Bot(string address, ObservableCollection<string> proxy, ObservableCollection<string> userAgents, ObservableCollection<string> referers, int numberThreads, int timeMin, int timeMax, bool followingLinks)
        {
            Address = address;
            Proxy = proxy;
            UserAgents = userAgents;
            Referers = referers;
            NumberThreads = numberThreads;
            TimeMin = timeMin;
            TimeMax = timeMax;
            FollowingLinks = followingLinks;
        }
    }
}
