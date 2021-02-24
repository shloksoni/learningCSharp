using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GenericsAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            var PrimeMinistersByYear = new Dictionary<int, string>();

            PrimeMinistersByYear.Add(1998, "Atal Bihari Vajpayee");
            PrimeMinistersByYear.Add(2014, "Narendra Modi");
            PrimeMinistersByYear.Add(2004, "Manmohan Singh");

            // Q1 -> Find the Prime minister of 2004.

            System.Console.WriteLine($"The PrimeMinister of 2004 was {PrimeMinistersByYear[2004]}");

            // Q2 -> Add current prime minister in the dictionary.
            PrimeMinistersByYear.Add(2021, "Narendra Modi");

            // Q3 -> Sort the dictionary by year.

            System.Console.WriteLine("\nPrime Ministers in sorted order by year: \n");
            foreach (var year in PrimeMinistersByYear)
            {
                System.Console.WriteLine("{0} : {1}", year.Key, year.Value);
            }




            
        }
    }
}
