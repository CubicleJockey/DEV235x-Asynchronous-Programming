using System;
using static System.Console;
using System.Threading.Tasks;

namespace Lab1
{
    public class AsyncCoinManager
    {

        public async Task AcquireAsyncCoin()
        {
            WriteLine($"Start call to long-running service at {DateTime.Now}");
            var result = await PretendToConnectToCoinService();
            WriteLine($"Finish call to long-running service at {DateTime.Now}");

            DisplayResultAsRed(result);
        }

        private static void DisplayResultAsRed(string result)
        {
            var savedColor = ForegroundColor;
            ForegroundColor = ConsoleColor.Red;

            WriteLine($"Result: [{result}]");

            ForegroundColor = savedColor;
        }

        private static async Task<string> PretendToConnectToCoinService()
        {
            await Task.Delay(5000);
            return "You've gotten 25 Async Coins";
        }
    }
}
