using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    public class CoinsController : Controller
    {
        private readonly AsyncCoinManager coinManager;

        public CoinsController()
        {
            coinManager = new AsyncCoinManager();
        }

        [HttpGet]
        public async Task<string> GetAsync()
        {
            return await coinManager.AquireCoinsAsync();
        }

        // GET api/values/5
        [HttpGet("{requestedAmount}")]
        public async Task<string> GetAsync(int requestedAmount = 5)
        {
            return await coinManager.AquireCoinsAsync(requestedAmount);
        }
    }
}
