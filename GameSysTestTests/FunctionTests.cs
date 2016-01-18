using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamesysExercise;

namespace GameSysExerciseTests
{
    [TestClass]
    public class FunctionTests
    {
        //Don't need to test SortedSet, it will be sorted and it will not have duplicates

        //1250 into GrowthRate returns 1 when FirstNumber is 1
        public const double GrowthRateBase = 1250.0;

        [TestMethod]
        public void GrowthRateFixedTest()
        {
            // When FirstNumber returns 1 GrowthRate will be fixed
            Func<double, double> firstMoq = x => 1;
            Assert.AreEqual(1.0, GameSysExercise.GrowthRateFunc(Math.PI, GrowthRateBase, firstMoq));
            Assert.AreEqual(1.0, GameSysExercise.GrowthRateFunc(double.MinValue, GrowthRateBase, firstMoq));
            Assert.AreEqual(1.0, GameSysExercise.GrowthRateFunc(double.MaxValue, GrowthRateBase, firstMoq));
        }

        [TestMethod]
        public void GrowthRateFirstZeroTest()
        {
            // 0 into FirstNumber returns 10/25
            //1250 into GrowthRate returns 1/FirstNumber(0)
            Assert.AreEqual(2.5, GameSysExercise.GrowthRateFunc(0, GrowthRateBase, GameSysExercise.FirstNumberFunc));
        }

        [TestMethod]
        public void GrowthRateFirstOneTest()
        {
            // 1 into FirstNumber returns 1.62 so 1/1.62
            double expectedResult = 1/1.62;
            Assert.AreEqual(expectedResult, GameSysExercise.GrowthRateFunc(1,GrowthRateBase, GameSysExercise.FirstNumberFunc));
        }

        [TestMethod]
        public void GrowthRateFirstGeneralTest()
        {
            // 1 into FirstNumber returns 1.62 so 1/1.62
            double expectedResult = 1 / 1.62;
            Assert.AreEqual(expectedResult, GameSysExercise.GrowthRateFunc(1, GrowthRateBase, GameSysExercise.FirstNumberFunc));
        }

        [TestMethod]
        public void GenerateSeriesZeroCountTest()
        {
            var set = GameSysExercise.GetSeries(1 , 1 , 0);
            Assert.IsNull(set);
        }

        [TestMethod]
        public void GenerateSeriesOneCountTest()
        {
            var set = GameSysExercise.GetSeries(1, 1, 1);
            Assert.AreEqual(1,set.Max);
            Assert.AreEqual(1, set.Count);
        }

        [TestMethod]
        public void GrowthRateTest()
        {
            // Hand calculated
            double expectedResult = 0.00045666327254774907;
            double result = GameSysExercise.GrowthRateFunc(4.7, 3.7, GameSysExercise.FirstNumberFunc);

            Assert.AreEqual(expectedResult,result);
        }

        [TestMethod]
        public void FirstNumberTest()
        {
            // Hand calculated
            double expectedResult = 5.1138;
            double result = GameSysExercise.FirstNumberFunc(3.7);
            Assert.AreEqual(ex6pectedResult,result);
            
        }


        [TestMethod]
        public void GeneratedSeriesTest()
        {
            var set = GameSysExercise.GetSeries(1.1, 1, 5);
            var expectedResult = new SortedSet<double>() {1.0, 1.25, 1.5};
            Assert.IsTrue(set.SetEquals(expectedResult));

            set = GameSysExercise.GetSeries(2.67, 4.29, 8);
            expectedResult = new SortedSet<double>() { 2.75, 11.5, 30.5, 81.75, 218.0, 582.0, 1554.25, 4150.0 };
            Assert.IsTrue(set.SetEquals(expectedResult));
        }

        [TestMethod]
        public void RoundingTest()
        {
            var RoundingSet = new SortedSet<double>(){0.0, 0.25, 0.5, 0.75, 1.0};
            var rnd = new Random((int)DateTime.Now.Ticks);

            for (int inded = 0; inded < 10; inded++)
            {
                double value = GameSysExercise.RoundToQuarter(rnd.NextDouble());
                Assert.IsTrue(RoundingSet.Contains(value));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughSetItemsException))]
        public void SpecialNumbersInvalidSetTest()
        {
            var set = new SortedSet<double>() { 100.0, 200.0 };
            var pair = GameSysExercise.GetSpecialNumbers(set, 13);
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughSetItemsException))]
        public void SpecialNumbersEmptySetTest()
        {
            var set = new SortedSet<double>() { };
            var pair = GameSysExercise.GetSpecialNumbers(set, 13);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SpecialNumbersNullSetTest()
        {
            var pair = GameSysExercise.GetSpecialNumbers(null, 13);
        }

        [TestMethod]
        public void SpecialNumbersTest()
        {
            var set = new SortedSet<double>() {1.34, 2.56, 3.78};
            var appxNum = GameSysExercise.ApproximateNumberFunc(16.5); // 46.25/16.5 = 2.803
            var expectedResult = new Tuple<double,double>(3.78, 2.56);
            var pair = GameSysExercise.GetSpecialNumbers(set, 16.5);
            Assert.AreEqual(expectedResult, pair);

            set = new SortedSet<double>() { 1.34, 2.56, 4.57, 5.69 ,10.47, 16.67 };
            appxNum = GameSysExercise.ApproximateNumberFunc(7.15); // 46.25/7.15 = 6.469
            expectedResult = new Tuple<double, double>(4.57, 5.69);
            pair = GameSysExercise.GetSpecialNumbers(set, 7.15);
            Assert.AreEqual(expectedResult, pair);
        }
    }

}
