using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UserBot.Services
{
    public interface IFileService
    {
        ObservableCollection<string> Open(string path);
    }
}
