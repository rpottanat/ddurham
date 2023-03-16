using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using name_sorter_library.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter_test
{
    [TestClass]
    public class FileSorter
    {
        private const string TestInputFile = "test-input.txt";
        private const string TestOutputFile = "test-output.txt";
        private readonly FileService _sut;
        private readonly Mock<ILogger<FileService>> _logger = new Mock<ILogger<FileService>>();

        public FileSorter()
        {
            _sut = new FileService(_logger.Object);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            //Arrage - Create a test input file
            using (StreamWriter writer = new StreamWriter(TestInputFile))
            {
                writer.WriteLine("Emma Rodriguez");
                writer.WriteLine("Julia Rodriguez Martinez");
                writer.WriteLine("Lowins John Middleton Jaffery");
                writer.WriteLine("Hunter Uria Mathew Clark Avalor");
                writer.WriteLine("Sophia Garcia Lopez");
                writer.WriteLine("Avery Johnson");
                writer.WriteLine("Avery Johnson Smith");
                writer.WriteLine("Mia");
            }
        }

        [TestMethod]
        public async Task ReadTheFileAndSort()
        {
            //Act        
            var sortedNames = await _sut.ReadFromFile(TestInputFile);

            // Assert
            Assert.AreEqual(sortedNames.Count, 6);
            Assert.AreEqual(sortedNames[0].ToString(), "Lowins John Middleton Jaffery");
            Assert.AreEqual(sortedNames[1].ToString(), "Avery Johnson");
            Assert.AreEqual(sortedNames[2].ToString(), "Sophia Garcia Lopez");
            Assert.AreEqual(sortedNames[3].ToString(), "Julia Rodriguez Martinez");
            Assert.AreEqual(sortedNames[4].ToString(), "Emma Rodriguez");
            Assert.AreEqual(sortedNames[5].ToString(), "Avery Johnson Smith");
        }


        [TestMethod]
        public async Task WriteIntoFile_AfterReadTheFileAndSort()
        {
            //Act
            var sortedNames = await _sut.ReadFromFile(TestInputFile);
            _ = await _sut.WriteToFile(TestOutputFile, sortedNames);
            sortedNames = await _sut.ReadFromFile(TestOutputFile);

            // Assert
            Assert.AreEqual(sortedNames.Count, 6);
            Assert.AreEqual(sortedNames[0].ToString(), "Lowins John Middleton Jaffery");
            Assert.AreEqual(sortedNames[1].ToString(), "Avery Johnson");
            Assert.AreEqual(sortedNames[2].ToString(), "Sophia Garcia Lopez");
            Assert.AreEqual(sortedNames[3].ToString(), "Julia Rodriguez Martinez");
            Assert.AreEqual(sortedNames[4].ToString(), "Emma Rodriguez");
            Assert.AreEqual(sortedNames[5].ToString(), "Avery Johnson Smith");
        }
    }
}
