using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebSite.BL
{
    public static class File
    {
        public static List<string> FileReader(string path)
        {
            string[] proxy = null;
            using (var sr = new StreamReader(path))
            {
                var file = sr.ReadToEnd();
                proxy = file.Split("\n");
            }

            return proxy.ToList();
        }
    }
}
