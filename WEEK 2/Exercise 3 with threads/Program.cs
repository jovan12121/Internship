using System.Net;
using System.Threading;
namespace Exercise_3_with_threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string linkToFile = "https://github.com/pbatard/rufus/releases/download/v4.3/rufus-4.3.exe";
            int numberOfChunks = 4;
            var threads = new Thread[numberOfChunks];

            var tempFileDictionary = new Dictionary<int, string>();

            long fileSize = GetFileSize(linkToFile);
            long chunkSize = fileSize / numberOfChunks;

            for (int i = 0; i < numberOfChunks - 1; i++)
            {
                long startByte = i * chunkSize;
                long endByte = (i + 1) * chunkSize - 1;
                int index = i;
                threads[i] = new Thread(() =>
                {
                    string fileName = DownloadChunkAsync(startByte, endByte, linkToFile);
                    lock (tempFileDictionary)
                    {
                        tempFileDictionary.Add(index,fileName);
                    }
                });
            }
            int lastNumber = numberOfChunks - 1;
            threads[numberOfChunks - 1] = new Thread((index) =>
            {
                string fileName = DownloadChunkAsync((numberOfChunks - 1) * chunkSize, fileSize, linkToFile);
                lock (tempFileDictionary)
                {
                    tempFileDictionary.Add(lastNumber, fileName);
                }
            });

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            MergeFiles(tempFileDictionary);
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
        public static string DownloadChunkAsync(long startingByte, long endingByte, string linkToFile)
        {
            using (HttpClient client = new HttpClient())
            {
                var rangeHeader = new System.Net.Http.Headers.RangeHeaderValue(startingByte, endingByte);
                client.DefaultRequestHeaders.Range = rangeHeader;
                using (HttpResponseMessage response =  client.GetAsync(new Uri(linkToFile)).Result)
                {
                    HttpContent content = response.Content;
                    byte[] data = content.ReadAsByteArrayAsync().Result;
                    string fileName = Path.GetTempFileName();
                    File.WriteAllBytes(fileName, data);
                    return fileName;
                }
            }
        }
        public static void MergeFiles(Dictionary<int, string> files)
        {
            string downloadedFileName = "downloaded";

            using (var finalFileStream = new FileStream(downloadedFileName, FileMode.Create, FileAccess.Write))
            {
                foreach (var kvp in files.OrderBy(x => x.Key))
                {
                    string fileName = kvp.Value;
                    byte[] chunkData = File.ReadAllBytes(fileName);
                    finalFileStream.Write(chunkData, 0, chunkData.Length);
                    File.Delete(fileName);
                }
            }
        }

    }
}
