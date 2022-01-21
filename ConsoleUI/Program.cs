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
            decimal[] songs = { 14, 12, 14, 12, 29, 12, 16, 11, 14, 6, 14, 14 };
            decimal mean = Mean(songs);
            decimal median = Median(songs);
            Dictionary<decimal,int> mode = TheMode(songs);
            Console.WriteLine($"The mean is: {mean}");
            Console.WriteLine($"The median is: {median}");
            foreach (var item in mode)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }

        private static void ATmr_Elapsed(object sender, ElapsedEventArgs e)
        {
        }

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
    }
}
