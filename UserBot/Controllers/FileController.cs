using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using UserBot.Services;

namespace UserBot.Controllers
{
    public class FileController : IFileService
    {
        public ObservableCollection<string> Open(string path)
        {
            List<string> listLine = default;
            using (StreamReader sr = new StreamReader(path))
            {
                listLine = sr.ReadToEnd().Split('\n').ToList();
            }

            return new ObservableCollection<string>(listLine);
        }
    }
}
