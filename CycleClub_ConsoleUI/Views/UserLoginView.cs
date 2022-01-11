using CycleClub_ConsoleUI.Data;
using CycleClub_ConsoleUI.FieldValidators;
using CycleClub_ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub_ConsoleUI.Views
{
    public class UserLoginView : IView
    {
        ILogIn _loginUser = null;
        public IFieldValidator FieldValidator => null;
        public UserLoginView(ILogIn login)
        {
            _loginUser = login;
        }


        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();


            Console.WriteLine("Please enter your email address.");

            string emailAddress = Console.ReadLine();

            Console.WriteLine("Please enter your password.");

            string password = Console.ReadLine();

            User user = _loginUser.Login(emailAddress, password);


            if (user != null)
            {
                WelcomUserView welcomUserView = new WelcomUserView(user);
                welcomUserView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials that you entered do not match our records.");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadLine();
            }
        }
    }
}
