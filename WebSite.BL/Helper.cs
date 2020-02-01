using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebSite.BL
{
    public static class Helper
    {
        public static List<string> IsListIPAddress(this List<string> listIPAddress)
        {
            if(listIPAddress != null)
            {
                for (int i = 0; i < listIPAddress.Count; i++)
                {
                    var ip = listIPAddress[i].Split(':');
                    if (ip.Length == 2)
                    {
                        if (!IPAddress.TryParse(ip[0], out var ipRes) || !int.TryParse(ip[1], out var port))
                        {
                            listIPAddress.RemoveAt(i);
                        }
                    }
                    else if (ip.Length == 1)
                    {
                        if (!IPAddress.TryParse(ip[0], out var ipRes))
                        {
                            listIPAddress.RemoveAt(i);
                        }
                    }
                    else
                    {
                        listIPAddress.RemoveAt(i);
                    }
                }
            }
            return listIPAddress;
        }
    }
}
