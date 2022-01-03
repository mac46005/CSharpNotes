using System;
using System.IO;
using AdvancedTopicsYT;
using Algorithms;

namespace ConsoleUI
{
    class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            ArrayTypes arrayTypes = new ArrayTypes();
            arrayTypes.SingleDimensionalArrays();
        }
    }
}
