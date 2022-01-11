using CycleClub_ConsoleUI.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub_ConsoleUI.Views
{
    public class MainView : IView
    {
        IView _registerView = null;
        IView _loginView = null;

        public MainView(IView registerView,IView loginView)
        {
            _registerView = registerView;
            _loginView = loginView;
        }


        public IFieldValidator FieldValidator => null;

        public void RunView()
        { 
            CommonOutputText.WriteMainHeading();
            Console.WriteLine("Please press 'l' to login or if not registered please press the 'r' key to register.");

            ConsoleKey key = Console.ReadKey().Key;

            if(key == ConsoleKey.R)
            {
                RunRegistrationView();
                RunLoginView();
            }
            else if (key == ConsoleKey.L)
            {
                RunLoginView();
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Goodbye");
                Console.ReadKey();
            }
        }


        private void RunRegistrationView()
        {
            _registerView.RunView();
        }

        public void RunLoginView()
        {
            _loginView.RunView();
        }


    }
}
