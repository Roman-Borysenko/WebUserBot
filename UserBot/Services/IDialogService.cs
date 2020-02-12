using System;
using System.Collections.Generic;
using System.Text;

namespace UserBot.Services
{
    public interface IDialogService
    {
        string FilePath { get; set; }
        bool OpenFile();
        bool SaveFile();
        void ShowMessage(string message);
    }
}
