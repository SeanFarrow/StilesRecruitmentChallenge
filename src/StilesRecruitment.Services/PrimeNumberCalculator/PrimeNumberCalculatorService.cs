// -----------------------------------------------------------------------
// <copyright file="PrimeNumberCalculatorService.cs" company="Stiles Recruitment LTD">
// Copyright (c) Stiles Recruitment LTD, 2014. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace StilesRecruitment.Services.PrimeNumberCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using StilesRecruitment.Infrastructure.ExtensionMethods;

    /// <summary>
    ///     Provides functions to calculate prime numbers.
    /// </summary>
    public class PrimeNumberCalculatorService : IPrimeNumberCalculatorService
    {
        #region Fields

        /// <summary>
        ///     Store the list of primes we have calculated.
        /// </summary>
        private readonly IList<ulong> calculatedprimes;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrimeNumberCalculatorService" /> class.
        /// </summary>
        public PrimeNumberCalculatorService()
        {
            this.calculatedprimes = new List<ulong>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Calculate all prime numbers within a given range.
        /// </summary>
        /// <param name="lowerLimit">The lower limit from which to start prime number calculation.</param>
        /// <param name="upperLimit">The upper limit at which to finish prime number calculation. </param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the lower limit is less than 2.</exception>
        /// <exception cref="ArgumentException">Thrown when the upper limit is greater than the lower limit.</exception>
        /// <returns>The calculated prime numbers.</returns>
        public IEnumerable<ulong> CalculatePrimesInRange(ulong lowerLimit, ulong upperLimit)
        {
            if (lowerLimit < 2)
            {
                throw new ArgumentOutOfRangeException("The lower limit must be greater than or equal to 2.");
            }

            if (lowerLimit > upperLimit)
            {
                throw new ArgumentException("The lower limit should not be greater than the upper limit.");
            }

            // store the original upper and lower limits for later use when extracting the numbers we want from the list of calculated primes..
            ulong oldUpperLimit = upperLimit;
            ulong oldLowerLimit = lowerLimit;
//Calculate the number of possible primes given our limits. Notice that we increase the upper limit by 1 as the range algorithm uses a half-open range.
            ulong numberOfPrimes = upperLimit++ - lowerLimit;
            IEnumerable<ulong> possiblePrimes = lowerLimit.Range(numberOfPrimes).Where(x =>x%2 !=0 || x==2).Except(this.calculatedprimes);

            // now iterate this list and determine which of these are primes.
            foreach (ulong possiblePrime in possiblePrimes)
            {
                    // check primality.
                    if (possiblePrime.IsPrime())
                    {
                        this.calculatedprimes.Add(possiblePrime);
                    } // end checking primality.
            } // end the foreach loop.
            // now return the primes.
            return from p in this.calculatedprimes where p >= oldLowerLimit && p <= oldUpperLimit select p;
        }

        #endregion
    }
}