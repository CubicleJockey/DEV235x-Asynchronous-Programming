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

        public static void Main(string[] args)
        {
            asyncCoinManager.AcquireAsyncCoin();

            Write("Press any key to exit...");
            ReadLine();
        }
    }
}
