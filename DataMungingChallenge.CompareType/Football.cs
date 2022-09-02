using System;
using System.Collections.Generic;
using System.Text;

namespace DataMungingChallenge.CompareType
{
    public class Football : BaseValueCompare
    {
        public int ScoresFor { get { return Value1; } set { Value1 = value; } }
        public int ScoresAgainst { get { return Value2; } set { Value2 = value; } }
        public override string RegularExpression { get { return @".*\. (\w+) +\d+ +\d+ +\d+ +\d+ +(\d+) +- +(\d+)"; } }

        public Football()
        {
        }

        public Football(string name, string scoresFor, string scoresAgainst)
            : base(name, Int32.Parse(scoresFor), Int32.Parse(scoresAgainst))
        {
        }
    }
}
