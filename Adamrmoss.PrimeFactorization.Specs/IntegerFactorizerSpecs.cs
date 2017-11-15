using System;
using FluentAssertions;
using NUnit.Framework;

namespace Adamrmoss.PrimeFactorization.Specs
{
    [TestFixture]
    public class IntegerFactorizerSpecs
    {
        private IntegerFactorizer integerFactorizer;

        [SetUp]
        public void Setup()
        {
            this.integerFactorizer = new IntegerFactorizer();
        }

        [Test]
        public void WhenIFactorizeAPrimeNumber_ThenIReturnOnlyThatNumber()
        {
            var result = this.integerFactorizer.GetPrimeFactors(11);

            result.ShouldBeEquivalentTo(new[] { 11 });
        }

        [Test]
        public void WhenIFactorizeTheNegationOfAPrimeNumber_ThenIReturnNegativeOneAndThatNumber()
        {
            var result = this.integerFactorizer.GetPrimeFactors(11);

            result.ShouldBeEquivalentTo(new[] { -1, 11 });
        }

        [Test]
        public void WhenIFactorizeACompositeNumberWithNoRepeatedFactors_ThenIReturnAllFactors()
        {
            var result = this.integerFactorizer.GetPrimeFactors(30);

            result.ShouldBeEquivalentTo(new[] { 2, 3, 5 });
        }

        [Test]
        public void WhenIFactorizeACompositeNumberWithRepeatedFactors_ThenIReturnAllFactors()
        {
            var result = this.integerFactorizer.GetPrimeFactors(384);

            result.ShouldBeEquivalentTo(new[] { 2, 2, 2, 2, 2, 2, 2, 3 });
        }
    }
}
