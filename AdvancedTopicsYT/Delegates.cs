using System;
using System.IO;

namespace AdvancedTopicsYT{
    public class Log{

        public delegate void LogDel(string text);
        public void LogTextToScreen(string text){
            Console.WriteLine($"{DateTime.Now} : {text}");
        }

        public void LogTextToFile(string text){
            using(StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Log.txt"),true)){
                sw.WriteLine($"{DateTime.Now} : {text}");
            }
        }

        public void LogText(LogDel logDel,string text){
            Console.WriteLine($"From {nameof(LogText)}");
            logDel(text);
        }
    }
}