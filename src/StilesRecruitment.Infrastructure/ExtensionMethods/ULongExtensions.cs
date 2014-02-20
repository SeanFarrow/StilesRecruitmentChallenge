// -----------------------------------------------------------------------
// <copyright file="ULongExtensions.cs" company="Stiles Recruitment LTD">
// Copyright (c) Stiles Recruitment LTD, 2014. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace StilesRecruitment.Infrastructure.ExtensionMethods
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Class extending the <see cref="long" /> types functionality.
    /// </summary>
    public static class ULongExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Determine whether or not a number is prime.
        /// </summary>
        /// <param name="numberToCheck">The number to check for primality.</param>
        /// <returns>true if the number is prime, false otherwise.</returns>
        public static bool IsPrime(this ulong numberToCheck)
        {
            // Check to see if the number is 2. Ths is a short circuit, as we know 2 is the only even prime.
            if (numberToCheck == 2)
            {
                return true;
            }

            // Check to see if the number is even and is greater than 2.
            if (numberToCheck % 2 == 0)
            {
                return false;
            }

            // We don't need to check the full domain of numbers, we only need to check values upto and including the square root of the number we are checking taht are odd.
            var maxNumberToCheck = (ulong)Math.Sqrt(numberToCheck);
            for (ulong i = 3; i < numberToCheck; i += 2)
            {
                if (numberToCheck % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Generates a sequence of integral numbers within a specified range.
        /// </summary>
        /// <param name="start">The number to start generating from.</param>
        /// <param name="count">The number of elements to generate.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Start is less than 0. - or - start +count-1 is larger than
        ///     <see cref="long.MaxValue" />
        /// </exception>
        /// <returns>An IEnumerable`1{ulong} that contains a range of sequential integral numbers.</returns>
        public static IEnumerable<ulong> Range(this ulong start, ulong count)
        {
            ulong deltaToMaxValue = ulong.MaxValue - start;
                // the difference between the ulongs maximum value and our starting value.
            if (deltaToMaxValue < count)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            // Generate the range of values wanted.
            IList<ulong> generatedNumbers = new List<ulong>();
            for (ulong i = 0; i < count; i++)
            {
                generatedNumbers.Add(start + i);
            }

            return generatedNumbers;
        }

        #endregion
    }
}