using DataMunging.DataParser;
using DataMungingChallenge.Calculation;
using DataMungingChallenge.CompareType;
using System;
using System.Collections.Generic;

namespace DataMungingChallenge.Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Weather> weatherList = DataParser.Parse("../../../weather.dat", (a, b, c) => new Weather(a, b, c));
            DisplayData(weatherList);

            List<Football> footballList = DataParser.Parse("../../../football.dat", (a, b, c) => new Football(a, b, c));
            DisplayData(footballList);

            Console.ReadKey();
        }

        private static void DisplayData<T>(List<T> list) where T : BaseValueCompare
        {
            T data = DataCalculation.CalculateSmallestSpread(list);
            Console.WriteLine(data.ToString());
        }
    }
}
