using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using AdvancedTopicsYT;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] data1 = { 7,8,9,10,11,12,13,14,15 };
            decimal mean = Mean(data1);
            decimal median = Median(data1);
            RangeOfDataSet(data1);

            Dictionary<decimal,int> mode = TheMode(data1);
            Console.WriteLine($"The mean is: {mean}");
            Console.WriteLine($"The median is: {median}");

            Console.WriteLine("The Mode:");
            foreach (var item in mode)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("Standard Deviation");
            SampleStandardDeviation(data1);

            Console.ReadKey();
        }

        private static void ATmr_Elapsed(object sender, ElapsedEventArgs e)
        {
        }


        /// <summary>
        /// Measure of Center
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static decimal Mean(decimal[] dataSet)
        {
            Array.Sort(dataSet);
            decimal result = 0;
            decimal total = 0;
            foreach (decimal v in dataSet)
            {
                total += v;
            }
            result = total / dataSet.Length;
            return result;
        }

        /// <summary>
        /// Measures of Center
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static decimal Median(decimal[] dataSet)
        {
            decimal[] middle;
            int dataSetSize = dataSet.Length;
            decimal dataSetMiddleDecimal = (decimal)((decimal)dataSetSize / 2);
            int dataSetMiddleInt = (int)(dataSetSize / 2);
            Array.Sort(dataSet);
            if(dataSetMiddleDecimal == (decimal)dataSetMiddleInt)
            {
                middle = new decimal[] { dataSet[dataSetMiddleInt - 1], dataSet[dataSetMiddleInt] };
            }
            else
            {
                middle = new decimal[] { dataSet[dataSetMiddleInt] };
            }

            decimal result = 0;

            if(middle.Length > 1)
            {
                result = Mean(middle);
            }
            else
            {
                result = middle[0];
            }
            return result;
        }


        /// <summary>
        /// Measures of Centers
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static Dictionary<decimal,int> TheMode(decimal[] dataSet)
        {
            Array.Sort(dataSet);
            IEnumerable<decimal> distinctValues;
            distinctValues = dataSet.Distinct();

            Dictionary<decimal, int> keyValuePairs = new Dictionary<decimal, int>();
            foreach (var item in distinctValues)
            {
                keyValuePairs.Add(item, 0);
            }

            foreach (var item in dataSet)
            {
                if (keyValuePairs.ContainsKey(item))
                {
                    keyValuePairs[item] += 1;
                }
            }
            
            return keyValuePairs;
        }










        /// <summary>
        /// Measures of Variations
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static decimal RangeOfDataSet(decimal[] dataSet)
        {
            Array.Sort(dataSet);
            decimal[] sorted = dataSet;
            decimal result = sorted[sorted.Length - 1] - sorted[0];
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static void SampleStandardDeviation(decimal[] dataSet)
        {
            Array.Sort(dataSet);

            //Find the mean of the dataSet
            decimal mean = Mean(dataSet);

            //Find deviation for each dataset
            decimal[] deviationArray = new decimal[dataSet.Length];
            for (int i = 0; i < dataSet.Length; i++)
            {
                deviationArray[i] = dataSet[i] - mean;
            }


            // (x - mean)^2
            decimal[] sumOfSquaredDeviations = new decimal[dataSet.Length];
            for (int i = 0; i < dataSet.Length; i++)
            {

                sumOfSquaredDeviations[i] = deviationArray[i] * deviationArray[i];
            }

            for (int i = 0; i < dataSet.Length; i++)
            {
                Console.WriteLine($"{dataSet[i]}|{deviationArray[i]}|{sumOfSquaredDeviations[i]}");
            }


            decimal sumOfAllSquareDev = sumOfSquaredDeviations.Sum();
            decimal divideOverNumberOfObservations = sumOfAllSquareDev / (dataSet.Length - 1);
            double overallStandardDeviation = Math.Sqrt((double)divideOverNumberOfObservations);
            Console.WriteLine($"Standard Deviation: {overallStandardDeviation}");
        }
    }
}
