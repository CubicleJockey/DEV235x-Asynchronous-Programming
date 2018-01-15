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
        public async Task HowManyTimesWebService_DoWorkWhileRunning()
        {
            const int count = 20;

            //NOTE: Capturing the task triggers the execution
            var task = doWork.HowManyTimesWebServiceAsync(count);
            
            WriteLine("Counting while web task runs.");
            for (var i = 0; i < 10; i++) { WriteLine(i); }

            var response = await task;

            response.Should().NotBeNullOrWhiteSpace();

            //Display in Test Runner Console
            WriteLine(response);

            response.Should()
                .ContainEquivalentOf($"You've got {count} AsyncCoin!");
        }

        [TestMethod]
        public async Task XmlFileIoExample()
        {
            //Looks like Mac/Linux use bin/Debug/netcoreapp2.0
            var file =
                Path.Combine(Environment.CurrentDirectory, "Files", "books.xml");

            WriteLine($"File Path: [{file}]");

            var response = await doWork.CountNumberOfXmlNodes(file);

            response.Should().NotBeNullOrWhiteSpace();

            WriteLine(response);

            response.Should().BeEquivalentTo("342 total nodes!");
        }

        [TestMethod]
        public async Task XmlFileIoExample_DoWorkWhileRunning()
        {
            var file =
                Path.Combine(Environment.CurrentDirectory, "Files", "books.xml");

            WriteLine($"File Path: [{file}]");

            //NOTE: Capturing the task triggers the execution
            var task = doWork.CountNumberOfXmlNodes(file);

            WriteLine("Do some work while Xml File is being read.");
            for(var i = 0; i < 15; i++) {  WriteLine(i); }

            var response = await task;

            response.Should().NotBeNullOrWhiteSpace();

            WriteLine(response);

            response.Should().BeEquivalentTo("342 total nodes!");
        }

        [TestMethod]
        public void FileNotFound()
        {
            var fullFilePath = Path.Combine(Environment.CurrentDirectory, "NoFileFoundHereBuddy.txt");

            Action countNumberOfXmlNodesMethod = () => doWork.CountNumberOfXmlNodes(fullFilePath);

            countNumberOfXmlNodesMethod.ShouldThrow<FileNotFoundException>();
        }
    }
}
