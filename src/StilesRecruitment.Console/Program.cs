// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Stiles Recruitment LTD">
// Copyright (c) Stiles Recruitment LTD, 2014. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace StilesRecruitment.Console
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Ninject;
    using Ninject.Extensions.Conventions;

    using StilesRecruitment.Services.PrimeNumberCalculator;

    /// <summary>
    ///     main program class.
    /// </summary>
    internal class Program
    {
        #region Methods

        /// <summary>
        ///     The main program method.
        /// </summary>
        /// <param name="args">Argument passed to the program on the command line.</param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Prime number calculator.");
            Console.WriteLine("This program will calculate two sets of prime numbers and then show the time taken for both calculations.");
            
            // Use Ninject to show that the prime number calculation can be done using dependency injection.
            IKernel ninjectKernel = new StandardKernel();
            
            // bind all classes that implement an interface in the current appdomain to there default interface using ninject convensions.
            ninjectKernel.Bind(
                x =>
                    x.From(AppDomain.CurrentDomain.GetAssemblies())
                        .SelectAllClasses()
                        .BindDefaultInterface()
                        .Configure(c => c.InSingletonScope()));

            // Obtain the prime number calculation service from the kernel.
            var primeCalculator = ninjectKernel.Get<IPrimeNumberCalculatorService>();

            // We're going to calculate 2 sets of primes, to show the speed increase of the algorithm when primes have already been calculated.
            try
            {
                ulong lowerLimit, upperLimit = 0;
                string valueFromConsole;
                
                // Now ask the user for the first set of numbers.
                Console.WriteLine("Please enter the number you wish to start calculating primes from:");
                valueFromConsole = Console.ReadLine();
                if (!ulong.TryParse(valueFromConsole, out lowerLimit))
                {
                    throw new InvalidOperationException("Please enter a ulong value for the first lower limit.");
                }
                
                Console.WriteLine("Please enter the number you wish to finish calculating primes from:");
                valueFromConsole = null;
                valueFromConsole = Console.ReadLine();
                if (!ulong.TryParse(valueFromConsole, out upperLimit))
                {
                    throw new InvalidOperationException("Please enter a ulong value for the first upper limit.");
                }

                var watch = new Stopwatch();
                watch.Start();
                IList<ulong> firstPrimes = primeCalculator.CalculatePrimesInRange(lowerLimit, upperLimit).ToList();
                watch.Stop();
                TimeSpan firstPrimeCalculationTime = watch.Elapsed;

                // Now calculate the second set of primes.
                lowerLimit = 0;
                upperLimit = 0;
                valueFromConsole = null;

                // Now ask the user for the second set of numbers.
                Console.WriteLine("Now calculating the second set of primes.");
                Console.WriteLine("Please enter the number you wish to start calculating primes from:");
                valueFromConsole = Console.ReadLine();
                if (!ulong.TryParse(valueFromConsole, out lowerLimit))
                {
                    throw new InvalidOperationException("Please enter a ulong value for the second lower limit.");
                }

                Console.WriteLine("Please enter the number you wish to finish calculating primes from:");
                valueFromConsole = null;
                valueFromConsole = Console.ReadLine();
                if (!ulong.TryParse(valueFromConsole, out upperLimit))
                {
                    throw new InvalidOperationException("Please enter a ulong value for the second upper limit.");
                }

                watch.Reset();
                watch.Start();
                IList<ulong> secondPrimes = primeCalculator.CalculatePrimesInRange(lowerLimit, upperLimit).ToList();
                watch.Stop();
                TimeSpan secondPrimeCalculationTime = watch.Elapsed;
                
                // Display both sets of primes.
                Console.WriteLine("The first set of primes calculated were:");
                foreach (ulong prime in firstPrimes)
                {
                    Console.WriteLine(prime);
                }

                Console.WriteLine("This took {0}", firstPrimeCalculationTime);
                Console.WriteLine("The second set of primes calculated were:");
                foreach (ulong prime in secondPrimes)
                {
                    Console.WriteLine(prime);
                }

                Console.WriteLine("This took {0}", secondPrimeCalculationTime);
                TimeSpan timeDifference = firstPrimeCalculationTime.Subtract(secondPrimeCalculationTime);
                Console.WriteLine("The difference between the two runs was {0}", timeDifference);
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occured.");
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}