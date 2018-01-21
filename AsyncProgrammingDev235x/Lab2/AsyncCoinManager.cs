using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    public class AsyncCoinManager
    {
        public async Task<string> AquireCoinsAsync(int requestedAmount = 10)
        {
            var message = new StringBuilder();
            message.AppendLine($"Your mining operation started at [{DateTime.Now}].");

            var result = await PretendToConnectToCoinService(requestedAmount);

            message.AppendLine($"Your mining operation finished at [{DateTime.Now}].");
            message.AppendLine($"Result: [{result}].");

            return message.ToString();
        }

        private static async Task<string> PretendToConnectToCoinService(int requestedAmount = 10)
        {
            // Simulate a long-running network connection
            await Task.Delay(requestedAmount * 1000);

            return $"You've got {requestedAmount} AsyncCoin!";
        }
    }
}
