using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Adamrmoss.PrimeFactorization.Specs
{
    [TestFixture]
    public class IntegerLoaderSpecs
    {
        private IntegerLoader integerLoader;

        [SetUp]
        public void Setup()
        {
            this.integerLoader = new IntegerLoader();
        }

        [Test]
        public void WhenILoadNonExistantFile_ThenIFail()
        {
            Action loadingFileAction = () => this.integerLoader.GetIntegersFromFile("Fixtures/NotAnActualFile.txt");

            loadingFileAction.ShouldThrow<FileNotFoundException>();
        }

        [Test]
        public void WhenILoadInvalidFile_ThenIFail()
        {
            Action loadingFileAction = () => this.integerLoader.GetIntegersFromFile("Fixtures/InvalidInput.txt");

            loadingFileAction.ShouldThrow<FormatException>();
        }

        [Test]
        public void WhenILoadValidFile_ThenIDontFail()
        {
            Action loadingFileAction = () => this.integerLoader.GetIntegersFromFile("Fixtures/ValidInput.txt");

            loadingFileAction.ShouldNotThrow<Exception>();
        }

        [Test]
        public void WhenILoadValidFile_ThenIGetAListOfIntegers()
        {
            var ints = this.integerLoader.GetIntegersFromFile("Fixtures/ValidInput.txt");

            ints.ShouldBeEquivalentTo(new[] { 2, 6, 9, 79, 83, 89, 97, 202 });
        }
    }
}
