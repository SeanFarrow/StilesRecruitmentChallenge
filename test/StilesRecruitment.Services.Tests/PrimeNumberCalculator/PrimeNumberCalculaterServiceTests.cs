// -----------------------------------------------------------------------
// <copyright file="PrimeNumberCalculaterServiceTests.cs" company="Stiles Recruitment LTD">
// Copyright (c) Stiles Recruitment LTD, 2014. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace StilesRecruitment.Services.Tests.PrimeNumberCalculator
{
    using System;

    using NUnit.Framework;

    using StilesRecruitment.Services.PrimeNumberCalculator;

    /// <summary>
    ///     Test the <see cref="PrimeNumberCalculatorService" />
    /// </summary>
    [TestFixture]
    public class PrimeNumberCalculaterServiceTests
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Tests that a populated <see cref="IEnumerable`1{long}" /> is thrown when the calculation succeeds.
        /// </summary>
        [Test]
        public void CalculatePrimesInRange_ReturnsAPopulatedCollectionWhenTheCalculationSucceeds()
        {
            var primeCalculator = new PrimeNumberCalculatorService();
            Assert.That(primeCalculator.CalculatePrimesInRange(2, 200), Is.Not.Empty);
        }

        /// <summary>
        ///     Tests that an <see cref="ArgumentException" /> is thrown when the lower limit passed in to the
        ///     <see cref="CalculatePrimesInRange" /> method is grater than the upper limit.
        /// </summary>
        [Test]
        public void CalculatePrimesInRange_ThrowsAnArgumentExceptionWhenTheLowerLimitIsGreaterThanTheUpperLimit()
        {
            var primeCalculator = new PrimeNumberCalculatorService();
            Assert.Throws<ArgumentException>(() => primeCalculator.CalculatePrimesInRange(20, 5));
        }

        /// <summary>
        ///     Tests that an <see cref="ArgumentOutOfRangeException" /> is thrown when the lower limit passed in to the
        ///     <see cref="CalculatePrimesInRange" /> method is less than 2.
        /// </summary>
        [Test]
        public void CalculatePrimesInRange_ThrowsAnArgumentOutOfRangeExceptionWhenTheLowerLimitIsLessThan2()
        {
            var primeCalculator = new PrimeNumberCalculatorService();
            Assert.Throws<ArgumentOutOfRangeException>(() => primeCalculator.CalculatePrimesInRange(0, 5));
        }

        #endregion
    }
}