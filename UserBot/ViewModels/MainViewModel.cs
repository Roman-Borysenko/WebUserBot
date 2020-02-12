using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UserBot.Controllers;
using UserBot.Models;
using UserBot.Services;

namespace UserBot.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Bot userBot;
        public CommandController StartCommand { get; set; }

        IDialogService dialogService;

        public Bot BotUser {
            get { return userBot; }
            set
            {
                userBot = value;
                OnPropertyChanged("BotUser");
            } 
        }
        public MainViewModel()
        {
            //BotUser = new Bot(ConfigurationManager.AppSettings["Address"]);
            BotUser = new Bot(ConfigurationManager.AppSettings["Address"], null, new ObservableCollection<string> { ConfigurationManager.AppSettings["UserAgent"] }, new ObservableCollection<string> { ConfigurationManager.AppSettings["Referer"] }, int.Parse(ConfigurationManager.AppSettings["NumberThreads"]), int.Parse(ConfigurationManager.AppSettings["TimeMin"]), int.Parse(ConfigurationManager.AppSettings["TimeMax"]), bool.Parse(ConfigurationManager.AppSettings["FollowingLinks"]));
            StartCommand = new CommandController(StartBot);
            dialogService = new DefaultDialogController();
        }

        public void StartBot(object obj)
        {
            //BotUser.NumberThreads = 5;
            //BotUser.Address = "https://www.youtube.com/";
            //BotUser.TimeMin = 10;
            //BotUser.TimeMax = 20;
            dialogService.ShowMessage(BotUser.NumberThreads + " " + BotUser.Address);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
