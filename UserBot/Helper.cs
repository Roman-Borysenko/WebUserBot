﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace UserBot
{
    public static class Helper
    {
        public static ObservableCollection<string> IsListIPAddress(this ObservableCollection<string> listIPAddress)
        {
            if (listIPAddress != null && listIPAddress.Count > 0)
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
            else
            {
                listIPAddress = null;
            }
            return listIPAddress;
        }

        public static bool IsUrl(this string address)
        {
            bool isUrl = true;
            try
            {
                var urlArray = address.Split("//")?[1].Trim('/');
                Ping ping = new Ping();
                PingReply reply = ping.Send(urlArray);

                if (reply.Status != IPStatus.Success)
                {
                    isUrl = false;
                }
            }
            catch
            {
                isUrl = false;
            }
            return isUrl;
        }

        public static ObservableCollection<string> IsStringList(this ObservableCollection<string> listString)
        {
            if (listString != null && listString.Count > 0)
            {
                for (int i = 0; i < listString.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(listString[i]))
                    {
                        listString.RemoveAt(i);
                    }
                }
            }
            else
            {
                listString = null;
            }
            return listString;
        }

        public static ObservableCollection<string> IsListUrl(this ObservableCollection<string> listUrl)
        {
            if (listUrl != null && listUrl.Count > 0)
            {
                for (int i = 0; i < listUrl.Count; i++)
                {
                    if (!listUrl[i].IsUrl())
                    {
                        listUrl.RemoveAt(i);
                    }
                }
            }
            else
            {
                listUrl = null;
            }

            return listUrl;
        }
    }
}
