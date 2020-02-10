using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UserBot.Models;

namespace UserBot.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Bot botUser;
        public Bot BotUser
        {
            get 
            {
                return botUser;
            }
            set 
            {
                botUser = value;
            }
        }
        public MainViewModel()
        {
            //BotUser = new Bot(ConfigurationManager.AppSettings["Address"]);
            BotUser = new Bot(ConfigurationManager.AppSettings["Address"], null, new ObservableCollection<string> { ConfigurationManager.AppSettings["UserAgent"] }, new ObservableCollection<string> { ConfigurationManager.AppSettings["Referer"] }, int.Parse(ConfigurationManager.AppSettings["NumberThreads"]), int.Parse(ConfigurationManager.AppSettings["TimeMin"]), int.Parse(ConfigurationManager.AppSettings["TimeMax"]), bool.Parse(ConfigurationManager.AppSettings["FollowingLinks"]));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
