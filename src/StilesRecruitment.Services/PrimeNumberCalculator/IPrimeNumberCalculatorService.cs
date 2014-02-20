// -----------------------------------------------------------------------
// <copyright file="IPrimeNumberCalculatorService.cs" company="Stiles Recruitment LTD">
// Copyright (c) Stiles Recruitment LTD, 2014. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace StilesRecruitment.Services.PrimeNumberCalculator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Provides functions to calculate prime numbers.
    /// </summary>
    public interface IPrimeNumberCalculatorService
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Calculate all prime numbers within a given range.
        /// </summary>
        /// <param name="lowerLimit">The lower limit from which to start prime number calculation.</param>
        /// <param name="upperLimit">The upper limit at which to finish prime number calculation. </param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the lower limit is less than 2.</exception>
        /// <exception cref="ArgumentException">Thrown when the upper limit is greater than the lower limit.</exception>
        /// <returns>The calculated prime numbers.</returns>
        IEnumerable<ulong> CalculatePrimesInRange(ulong lowerLimit, ulong upperLimit);

        #endregion
    }
}