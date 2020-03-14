using System.Collections.Generic;
using System.Net;

namespace UserBot.Controllers
{
    public class WebController
    {
        // user agent https://olegon.ru/user_agents.txt | https://bestweb4u.net/mobile-user-agent/ | https://techblog.willshouse.com/2012/01/03/most-common-user-agents/?__cf_chl_jschl_tk__=7c6ec92a6a6331f0bbb7cdfb3c5003a9b89d9eed-1580219130-0-AaZHpE_dNUsWO3OIoIAFPdoTOmhvCQk6E06WtImcPNPKYmHpjr5ZtdsWYbK5kiQlENY6VgeKco_i5GbRaUiKg1Sk2dQDHNdsVCgTjE2mTnEb0nzdk9RdZI3fN7MCAiLzutY29jfD9KVe8jcTZ3Il8dxRDb_1_BqIQYv5Up8h_04JvEhb9M7rwWVGhFEY8xhKjyk2rlYSxU2E2UWtuspksHZLGVkeG9Mq9JHbfG6NXyjlaf0xrYpnGh41jbvlmd6UezDWeQjeGD30lKvbu7086jrGc2ZIoK9U8zdTbzSccInjUj3xv2RWiFBgnlBIHDWW_fdlbJqnjJRNdqyY5_FcWMnnEiU3pItNniWpHDyysLuH212zFidxf4mWSNAKUqaF2w

        public static string GetHtml(string address, string proxy, string userAgent, string referer)
        {
            WebClient client = new WebClient();

            if (!string.IsNullOrWhiteSpace(proxy))
            {
                WebProxy wp = new WebProxy(proxy.ToString(), true); // 51.158.123.35:8811
                client.Proxy = wp;
            }

            if (!string.IsNullOrWhiteSpace(userAgent))
            {
                client.Headers[HttpRequestHeader.UserAgent] = userAgent;
            }

            if (!string.IsNullOrWhiteSpace(referer))
            {
                client.Headers[HttpRequestHeader.Referer] = referer;
            }

            client.Credentials = CredentialCache.DefaultNetworkCredentials;

            return client.DownloadString(address);
        }

        public static List<string> GetUrl(string html, string search)
        {
            var urlList = new List<string>();
            string[] lines = html.Split('\n');

            foreach (var line in lines)
            {
                var index = line.IndexOf(search);
                var result = "";
                if (index >= 0)
                {
                    index += search.Length;
                    while (line[index] != '"')
                    {
                        result += line[index];
                        index++;
                    }
                    urlList.Add(result);
                }
            }

            return urlList;
        }
    }
}
