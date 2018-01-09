using static System.Console;

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace AsyncProgrammingDev235x.DemoOne
{
    public class DoWork
    {
        /// <summary>
        /// This is an example of how to get async resources from an API
        /// 
        /// This is an I/O type of asynchronous call. Meaning it works best with Task, Task<T> and void.
        /// 
        /// Calculation (CPU) intensive asynchronous calls would use Task.Run(...)
        /// </summary>
        /// <param name="times">Number of Async Coins</param>
        /// <returns></returns>
        public Task<string> HowManyTimesWebServiceAsync(int times = 3)
        {
            Task<string> result;

            var uri = new Uri($"http://asynccoindemo.azurewebsites.net/api/asynccoin/{times}");

            using (var client = new WebClient())
            {
                result = client.DownloadStringTaskAsync(uri);
            }
            return result;
        }

        /// <summary>
        /// Example of xmlFile I/O async.
        /// 
        /// books.xml was created from https://msdn.microsoft.com/en-us/library/ms762271%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396
        /// </summary>
        /// <param name="xmlFile">Xml File</param>
        /// <returns></returns>
        public async Task<string> CountNumberOfXmlNodes(FileInfo xmlFile)
        {
            xmlFile.Refresh();
            if(!xmlFile.Exists) { throw new FileNotFoundException($"[{xmlFile.Name}] does not exist."); }

            var count = 0;

            var settings = new XmlReaderSettings { Async = true };

            using (var fileStream = xmlFile.OpenRead())
            {
                using (var xmlReader = XmlReader.Create(fileStream, settings))
                {
                    while (await xmlReader.ReadAsync())
                    {
                        WriteLine(xmlReader.NodeType == XmlNodeType.Element ? xmlReader.Name : xmlReader.Value);
                        count++;
                    }       
                }
            }
            return $"{count} total nodes!";
        }
    }
}
