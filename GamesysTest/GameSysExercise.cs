using System;
using System.Collections.Generic;
using System.Linq;

namespace GamesysExercise
{
    public class NotEnoughSetItemsException : Exception
    {
        public NotEnoughSetItemsException(string message) : base(message){}
    }

    public static class GameSysExercise
    {
        const double ApproxNumberFuncConstant = 46.25;
        public static Func<double, double> FirstNumberFunc = x => ((0.5*(Math.Pow(x, 2.0))) + (30.0*x) + 10.0)/25.0;
        public static Func<double, double, Func<double, double>, double> GrowthRateFunc = (x, y, fn ) => (y * 0.02) / 25.0 / fn(x);
        public static Func<double, double> RoundToQuarter = x => Math.Floor(x) + Convert.ToInt32((x - Math.Floor(x))*4.0) / 4.0;
        public static readonly Func<double, double> ApproximateNumberFunc = x => ApproxNumberFuncConstant/x;

        // Originally wrote this as a delegate function, changed my mind, this is clearer
        public static SortedSet<double> GetSeries(double firstNumber, double growthRate, int length)
        {
            if (length == 0) return null;

            var set = new SortedSet<double>();
            set.Add(RoundToQuarter(firstNumber));

            for (int index = 1; index < length; index++)
            {
                double nextInSeries = RoundToQuarter(growthRate*(Math.Pow(firstNumber, index)));
                set.Add(nextInSeries);
            }

            return set;
        }


        //Its not clear where x is supposed to be defined, this function isn't specifically requested, don't like magic numbers 
        public static Tuple<double, double> GetSpecialNumbers(SortedSet<double> set, double x)
        {
            if (set.Count < 3)
                throw new NotEnoughSetItemsException(
                    string.Format("GetSpecial numbers expects at least 3 items in the provided set, got {0}", set.Count));

            Tuple<double, double> pair = new Tuple<double, double>(set.ToList()[2],set.GetViewBetween(set.Min, ApproximateNumberFunc(x)).Max);
            return pair;
        }
    }
}


