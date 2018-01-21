using System;
using static System.Console;
using System.Threading;

namespace Lab1
{
    public class AsyncCoinManager
    {

        public void AcquireAsyncCoin()
        {
            WriteLine($"Start call to long-running service at {DateTime.Now}");
            var result = PretendToConnectToCoinService();
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

        private static string PretendToConnectToCoinService()
        {
            Thread.Sleep(5000);
            return "You've gotten 25 Async Coins";
        }
    }
}
