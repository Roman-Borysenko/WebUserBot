using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using UserBot.Services;

namespace UserBot.Controllers
{
    public class DefaultDialogController : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFile()
        {
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog() == true)
            {
                FilePath = file.FileName;
                return true;
            }
            return false;
        }

        public bool SaveFile()
        {
            SaveFileDialog file = new SaveFileDialog();
            if(file.ShowDialog() == true)
            {
                FilePath = file.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
