using CycleClub_ConsoleUI.FieldValidators;
using CycleClub_ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub_ConsoleUI.Views
{
    public class WelcomUserView : IView
    {
        User _user = null;
        public WelcomUserView(User user)
        {
            _user = user;
        }

        public IFieldValidator FieldValidator => throw new NotImplementedException();

        public void RunView()
        {
            Console.Clear();
            CommonOutputText.WriteMainHeading();
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Hi {_user.FirstName}{Environment.NewLine}Welcom to the cycling club!");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();

        }
    }
}
