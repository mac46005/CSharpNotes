using System;
using System.IO;
using System.Timers;
using AdvancedTopicsYT;

namespace ConsoleUI
{
    class Program
    {
        public static int secondsCount = 0;
        public static Timer aTmr = new Timer(1000);
        static void Main(string[] args)
        {
            aTmr.Elapsed += ATmr_Elapsed;
            aTmr.Enabled = true;
            aTmr.AutoReset = true;
            aTmr.Start();
            Console.ReadKey();
        }

        private static void ATmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            secondsCount++;
            Console.WriteLine(secondsCount + " Seconds");
        }
    }
}
