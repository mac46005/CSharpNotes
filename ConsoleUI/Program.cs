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
            logObject.Run();
        }
    }
}
