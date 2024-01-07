using System.Net;
using System.Threading;
using System.Threading.Tasks;
namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string linkToFile = "https://github.com/pbatard/rufus/releases/download/v4.3/rufus-4.3.exe";
            int numberOfChunks = 4;
            var tasks = new Task[numberOfChunks];
            var tempFiles = new string[numberOfChunks];
            long fileSize = GetFileSize(linkToFile);
            long chunkSize = fileSize/numberOfChunks;
            for (int i = 0; i < numberOfChunks - 1; i++)
            {
                long startByte = i * chunkSize;
                long endByte = (i+1) * chunkSize-1;
                tempFiles[i] = Path.GetTempFileName();
                tasks[i] = DownloadChunkAsync(startByte, endByte, linkToFile, tempFiles[i]);
            }
            tempFiles[numberOfChunks-1] = Path.GetTempFileName();
            tasks[numberOfChunks - 1] = DownloadChunkAsync((numberOfChunks - 1) * chunkSize, fileSize, linkToFile, tempFiles[numberOfChunks - 1]);
            Task.WhenAll(tasks).Wait();
            MergeFiles(tempFiles);
        }
        public static long GetFileSize(string url)
        {
            long result = -1;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = client.Send(new HttpRequestMessage(HttpMethod.Head, new Uri(url))))
                {
                    result = (long)responseMessage.Content.Headers.ContentLength;
                }
            }

            return result;
        }
        public static async Task DownloadChunkAsync(long startingByte,long endingByte,string linkToFile,string tempFile)
        {
            using(HttpClient client = new HttpClient())
            {
                var rangeHeader = new System.Net.Http.Headers.RangeHeaderValue(startingByte, endingByte);
                client.DefaultRequestHeaders.Range = rangeHeader;
                using(HttpResponseMessage response = await client.GetAsync(new Uri(linkToFile)))
                {
                    HttpContent content = response.Content;
                    byte[] data = await content.ReadAsByteArrayAsync();
                    File.WriteAllBytes(tempFile,data);
                }
            }
        }
        public static void MergeFiles(string[] files)
        {
            string downloadedFileName = "downloaded";
            using (var finalFileStream = new FileStream(downloadedFileName, FileMode.Create, FileAccess.Write))
            {
                foreach (var fileName in files)
                {
                    byte[] chunkData = File.ReadAllBytes(fileName);
                    finalFileStream.Write(chunkData, 0, chunkData.Length);
                    File.Delete(fileName);
                }
            }
        }
    }

}
