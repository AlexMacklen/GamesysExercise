using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace GamesysExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = GameSysExercise.FirstNumberFunc(4.7);
            var growthRate = GameSysExercise.GrowthRateFunc(4.7, 3.7,GameSysExercise.FirstNumberFunc);
            var set = GamesysExercise.GameSysExercise.GetSeries(firstNumber,growthRate,10);

            foreach (var item in set.ToList())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
