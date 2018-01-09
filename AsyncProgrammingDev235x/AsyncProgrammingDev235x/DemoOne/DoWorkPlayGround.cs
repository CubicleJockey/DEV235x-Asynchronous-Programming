using static System.Console;

using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncProgrammingDev235x.DemoOne
{
    [TestClass]
    public class DoWorkPlayGround
    {
        [TestMethod]
        public async Task HowManyTimesWebService_Basic()
        {
            const int count = 10;
            var doWork = new DoWork();

            var response = await doWork.HowManyTimesWebServiceAsync(count);
            
            response.Should().NotBeNullOrWhiteSpace();

            //Display in Test Runner Console
            WriteLine(response);

            response.Should()
                    .BeEquivalentTo($"You've got {count} AsyncCoin!");


        }
    }
}
