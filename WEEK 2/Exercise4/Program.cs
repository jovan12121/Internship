namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sitesToDownload = new List<string> { "https://www.google.com/", "https://www.bing.com/", "https://www.bbc.com/" };
            SiteData siteData = SiteDownloader.DownloadSitesAsync(sitesToDownload).Result;
            Console.WriteLine(siteData.SiteName);
            Console.WriteLine(siteData.SiteString);
        }
    }
}
