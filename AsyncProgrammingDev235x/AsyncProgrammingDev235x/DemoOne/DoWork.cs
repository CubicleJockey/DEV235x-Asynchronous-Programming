using System;
using System.Net;
using System.Threading.Tasks;

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
    }
}
