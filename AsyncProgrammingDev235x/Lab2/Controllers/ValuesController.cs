using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly AsyncCoinManager coinManager;

        public ValuesController()
        {
            coinManager = new AsyncCoinManager();
        }

        // GET api/values/5
        [HttpGet("{requestedAmount}")]
        public string Get(int requestedAmount)
        {
            return coinManager.AcquireAsyncCoin(requestedAmount);
        }
    }
}
