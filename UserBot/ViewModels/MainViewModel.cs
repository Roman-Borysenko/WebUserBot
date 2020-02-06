using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace UserBot.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> UserAgents { get; set; }
        public ObservableCollection<string> Referers { get; set; }
        public ObservableCollection<string> Proxy { get; set; }
        public MainViewModel()
        {
            // TODO: added list useragents
            UserAgents = new ObservableCollection<string> { "qweqwe", "asdasd", "asdasdsa" };
            Referers = new ObservableCollection<string> { "123123", "123123", "1231233" };
            Proxy = new ObservableCollection<string> { "123123", "123123", "1231233" };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
