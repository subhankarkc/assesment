using DataMungingChallenge.CompareType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataMungingChallenge.Calculation
{
    public static class DataCalculation
    {
        public static T CalculateSmallestSpread<T>(List<T> dataList) where T : BaseValueCompare
        {
            var sortedList = dataList.OrderBy(x => x.ValueDifference).ToList();

            return sortedList.First();
        }
    }
}
