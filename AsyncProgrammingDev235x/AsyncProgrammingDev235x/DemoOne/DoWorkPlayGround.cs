using static System.Console;

using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncProgrammingDev235x.DemoOne
{
    [TestClass]
    public class DoWorkPlayGround
    {
        private readonly DoWork doWork;

        public DoWorkPlayGround()
        {
            doWork = new DoWork();
        }

        [TestMethod]
        public async Task HowManyTimesWebService()
        {
            const int count = 10;
            
            var response = await doWork.HowManyTimesWebServiceAsync(count);
            
            response.Should().NotBeNullOrWhiteSpace();

            //Display in Test Runner Console
            WriteLine(response);

            response.Should()
                    .ContainEquivalentOf($"You've got {count} AsyncCoin!");
        }

        [TestMethod]
        public async Task XmlFileIoExample()
        {
            var path =
                Path.Combine(Environment.CurrentDirectory.Replace(@"\bin\Debug\netcoreapp2.0", string.Empty),
                             @"Files\books.xml");

            var file = new FileInfo(path);

            WriteLine($"File: [{file}].");

            var response = await doWork.CountNumberOfXmlNodes(file);

            response.Should().NotBeNullOrWhiteSpace();

            WriteLine(response);

            response.Should().BeEquivalentTo("342 total nodes!");
        }
    }
}
