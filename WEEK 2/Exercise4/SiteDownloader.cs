using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    public class SiteDownloader
    {
        public static async Task<SiteData> DownloadSitesAsync(List<string> sitesToDownload)
        {
            List<Task<SiteData>> tasks = new List<Task<SiteData>>();
            foreach (string site in sitesToDownload)
            {
                tasks.Add(DownloadSiteAsync(site));
            }
            var result = await Task.WhenAny(tasks).Result;
            return result;
        }
        public static async Task<SiteData> DownloadSiteAsync(string link)
        {
            HttpClient client = new HttpClient();
            SiteData returnValue = new SiteData();
            returnValue.SiteName = link;
            returnValue.SiteString = await client.GetStringAsync(link);
            return returnValue;
        }
    }
}
