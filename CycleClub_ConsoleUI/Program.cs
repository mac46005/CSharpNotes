using CycleClub_ConsoleUI.Views;
using System;

namespace CycleClub_ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IView mainView = Factory.GetMainViewObject();
            mainView.RunView();

            Console.ReadKey();
        }
    }
}
