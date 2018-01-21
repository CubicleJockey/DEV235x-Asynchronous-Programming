using System.Threading.Tasks;
using static System.Console;

namespace Lab1
{
    public class Program
    {
        private static readonly AsyncCoinManager asyncCoinManager;

        static Program()
        {
            asyncCoinManager = new  AsyncCoinManager();
        }

        public static async Task Main(string[] args)
        {
            var aquireCoinsTask = asyncCoinManager.AcquireAsyncCoin();

            WriteLine($"I am not blocked by the call to [{nameof(AsyncCoinManager.AcquireAsyncCoin)}] which was made in [{nameof(Main)}].");

            await aquireCoinsTask;

            Write("Press any key to exit...");
            ReadLine();
        }
    }
}
