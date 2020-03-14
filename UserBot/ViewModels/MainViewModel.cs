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
        private Bot botUser;
        public CommandController StartCommand { get; set; }
        public CommandController OpenFileCommand { get; set; }

        IFileService File;
        IDialogService dialogService;

        public Bot BotUser {
            get { return botUser; }
            set
            {
                botUser = value;
                OnPropertyChanged("BotUser");
            } 
        }
        public MainViewModel()
        {
            //BotUser = new Bot(ConfigurationManager.AppSettings["Address"]);
            BotUser = new Bot(ConfigurationManager.AppSettings["Address"], null, new ObservableCollection<string> { ConfigurationManager.AppSettings["UserAgent"] }, new ObservableCollection<string> { ConfigurationManager.AppSettings["Referer"] }, int.Parse(ConfigurationManager.AppSettings["NumberThreads"]), int.Parse(ConfigurationManager.AppSettings["TimeMin"]), int.Parse(ConfigurationManager.AppSettings["TimeMax"]), bool.Parse(ConfigurationManager.AppSettings["FollowingLinks"]));
            BotUser.ErrorEvent += ShowError;

            StartCommand = new CommandController(StartBot);
            OpenFileCommand = new CommandController(OpenFile);
            File = new FileController();

            dialogService = new DefaultDialogController();
        }

        public void StartBot(object obj)
        {
            BotUser.StartDoss();
        }

        public void OpenFile(object obj)
        {
            dialogService.OpenFile();
            var collection = File.Open(dialogService.FilePath);

            switch(obj as string)
            {
                case "UserAgent": botUser.UserAgents = collection; break;
                case "Referer": botUser.Referers = collection; break;
                case "Proxy": botUser.Proxy = collection; break;
            }
        }

        public void ShowError(string error)
        {
            dialogService.ShowMessageError(error);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
