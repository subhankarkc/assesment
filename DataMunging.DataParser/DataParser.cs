using DataMungingChallenge.CompareType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace DataMunging.DataParser
{
    public static class DataParser
    {
        /// <summary>
        /// Parses a text file of data for a specific type.
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="path">Path name</param>
        /// <param name="construct">Constructor expression</param>
        /// <returns>List of Type</returns>
        public static List<T> Parse<T>(string path, Func<string, string, string, T> construct) where T : BaseValueCompare, new()
        {
            List<T> dataList = new List<T>();

            // Read contents of text file.
            string text = File.ReadAllText(path);

            // Match on the regular expression.
            Regex regEx = new Regex(new T().RegularExpression, RegexOptions.IgnoreCase);
            MatchCollection matches = regEx.Matches(text);

            foreach (Match match in matches)
            {
                if (match.Groups.Count >= 3)
                {
                    // Populate data type.
                    T data = construct(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                    dataList.Add(data);
                }
            }

            return dataList;
        }
    }
}
