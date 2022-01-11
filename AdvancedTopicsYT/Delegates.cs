using System;
using System.IO;

namespace AdvancedTopicsYT{

    /// PART 1
    /// <summary>
    /// A delegate can be described as a type safe function pointer
    /// </summary>
    public class Log{

        /// <summary>
        /// This is how a delegate is declared
        /// Provide any return types and parameters to use the delegate
        /// </summary>
        /// <param name="text">Enter any number of parameters that multiple functions share for flexibility</param>
        private delegate void LogDel(string text);


        /// <summary>
        /// This function is one of the functions used in the delegate call
        /// </summary>
        /// <param name="text"></param>
        private void LogTextToScreen(string text){
            Console.WriteLine($"{DateTime.Now} : {text}");
        }

        /// <summary>
        /// This is another function that is used in the delegate call
        /// </summary>
        /// <param name="text"></param>
        private void LogTextToFile(string text){
            using(StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Log.txt"),true)){
                sw.WriteLine($"{DateTime.Now} : {text}");
            }
        }

        /*
        Notice that the above methods have the same return type and parameter list.
        Therefore these two methods can be used for the delegate declared.

        Ofcourse make the delegate name conscise with make is to be used for.
        As well as methods and variables and well everything in general.
        */

        /// <summary>
        /// You can also add the delegate as a parameter.
        /// Which can add flexibility to the functionality to the method itself.
        /// </summary>
        /// <param name="logDel"></param>
        /// <param name="text"></param>
        private void LogText(LogDel logDel,string text){
            Console.WriteLine($"From {nameof(LogText)}");

            // When this delegate is called it will call any methods called
            // In the run example I combined two delegates into one so that both methods are called when
            // This method is called.
            logDel(text);
        }

        /// <summary>
        /// Run this example to see the result yo.
        /// </summary>
        public void Run(){
            Console.Write("Input text here:");
            var text = Console.ReadLine();

            // I declared to delegate types that take in two different methods with different functionalities
            LogDel textToScreen = new LogDel(LogTextToScreen);
            LogDel textToFile = new LogDel(LogTextToFile);

            // Invoking both methods
            textToScreen(text);

            textToFile(text);

            // This is interesting
            // I combined both delegates to make a super delegate.
            LogDel multiDelegate = textToScreen + textToFile;

            Console.WriteLine("Calling the multiDelegate.");
            // the invoked the delegate which inturn calles both methods to run
            multiDelegate(text);


            Console.ReadLine();
        }
    }




    // Part 2 Delegates
    // Look at Cycle Club Registration console application and referenced libraries

    // Part 3 Covariance & Contravariance

    public class CovarianceExample
    {
        public class BaseClass
        {
            // class code
        }

        public class DerivedClass : BaseClass
        {
            // class code
        }

        delegate BaseClass MyDelegate();

        public static DerivedClass MyMethod()
        {
            // method code
            return new DerivedClass();
        }

        public static void Run()
        {
            MyDelegate myDelegate = MyMethod;
        }
    }

    

}