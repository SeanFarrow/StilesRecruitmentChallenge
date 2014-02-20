// -----------------------------------------------------------------------
// <copyright file="ULongExtensionsTests.cs" company="Stiles Recruitment LTD">
// Copyright (c) Stiles Recruitment LTD, 2014. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace StilesRecruitment.Infrastructure.Tests.ExtensionMethods
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using StilesRecruitment.Infrastructure.ExtensionMethods;

    /// <summary>
    ///     Test the <see cref="ULongExtensions" />
    /// </summary>
    [TestFixture]
    public class ULongExtensionsTests
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Test that false is returned when the number is even.
        /// </summary>
        [Test]
        public void IsPrime_ReturnsFalseWhenTheNumberIsEven()
        {
            ulong value = 4;
            Assert.That(value.IsPrime(), Is.False);
        }

        /// <summary>
        ///     Test that false is returned when the number being tested is odd and not prime.
        /// </summary>
        [Test]
        public void IsPrime_ReturnsFalseWhenTheNumberIsOddAndNotPrime()
        {
            ulong value = 21;
            Assert.That(value.IsPrime(), Is.False);
        }

        /// <summary>
        ///     Test that IsPrime returns true when the number being checked is 2, as this is the only even prime.
        /// </summary>
        [Test]
        public void IsPrime_ReturnsTrueWhenTheNumberBeingCheckedIs2()
        {
            ulong value = 2;
            Assert.That(value.IsPrime(), Is.True);
        }

        /// <summary>
        ///     test that true is returned when the number is prime.
        /// </summary>
        [Test]
        public void IsPrime_ReturnsTrueWhenTheNumberIsPrime()
        {
            ulong value = 3467;
            Assert.That(value.IsPrime(), Is.True);
        }

        /// <summary>
        ///     Test that a a collection with the number of elements requested is returned when the ranged is generated
        ///     successfully.
        /// </summary>
        [Test]
        public void Range_ReturnsACollectionWithTheNumberOfElementsRequestedInWhenTheRangeIsGeneratedSuccessfully()
        {
            int numberOfElementsWanted = 10;
            ulong start = 10;
            Assert.That(numberOfElementsWanted, Is.EqualTo(start.Range(10).Count()));
        }

        /// <summary>
        ///     Test that an <see cref="ArgumentOutOfRangeException" /> is thrown when the starting number +the number of items
        ///     wanted will overflow the ulongs maximum value.
        /// </summary>
        [Test]
        public void Range_ThrowsAnArgumentOutOfRangeExceptionWhenTheRangeWillExceedTheULongsMaximumAvailableValue()
        {
            ulong test = ulong.MaxValue - 10;
            Assert.Throws<ArgumentOutOfRangeException>(() => test.Range(20));
        }

        #endregion
    }
}