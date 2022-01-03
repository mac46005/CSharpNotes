using System;
using System.IO;
using AdvancedTopicsYT;

namespace ConsoleUI
{
    class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log logObject = new Log();

            Log.LogDel logDel = new Log.LogDel(logObject.LogTextToScreen);
            logDel("This is testing delegate from Log.LogDel");

            Console.WriteLine();

            logDel = new Log.LogDel(logObject.LogTextToFile);
            logDel("Marco Preciado");

            Console.ReadKey();
        }
    }
}
