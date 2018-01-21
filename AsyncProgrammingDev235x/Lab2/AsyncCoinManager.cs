using System;
using System.Text;
using System.Threading;

namespace Lab2
{
    public class AsyncCoinManager
    {
        public string AcquireAsyncCoin(int requestedAmount = 10)
        {
            var message = new StringBuilder();
            message.AppendLine($"Your mining operation started at [{DateTime.Now}].");

            var result = PretendToConnectToCoinService(requestedAmount);

            message.AppendLine($"Your mining operation finished at [{DateTime.Now}].");
            message.AppendLine($"Result: [{result}].");

            return message.ToString();
        }

        private static string PretendToConnectToCoinService(int requestedAmount = 10)
        {
            // Simulate a long-running network connection
            Thread.Sleep(requestedAmount * 1000);
            return $"You've got {requestedAmount} AsyncCoin!";
        }
    }
}
