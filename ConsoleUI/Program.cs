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

            Log.LogDel textToScreen, textToFile;
            textToScreen = new Log.LogDel(logObject.LogTextToScreen);
            textToFile = new Log.LogDel(logObject.LogTextToFile);

            Log.LogDel multiDelLog = textToFile + textToScreen;

            Console.WriteLine("Input your name yo:");
            var input = Console.ReadLine();

            multiDelLog(input);

            logObject.LogText(multiDelLog,input);

            Console.ReadKey();
        }
    }
}
