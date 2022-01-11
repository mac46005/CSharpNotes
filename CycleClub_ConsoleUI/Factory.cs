using CycleClub_ConsoleUI.Data;
using CycleClub_ConsoleUI.FieldValidators;
using CycleClub_ConsoleUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub_ConsoleUI
{
    public static class Factory
    {
        public static IView GetMainViewObject()
        {
            ILogIn login = new LoginUser();

            IRegister register = new RegisterUser();
            IFieldValidator userRegistrationFieldValidator = new UserRegistrationValidator(register);
            userRegistrationFieldValidator.InitializeValidatorDelegates();

            IView registerView = new UserRegistrationView(register, userRegistrationFieldValidator);
            IView loginView = new UserLoginView(login);

            IView mainView = new MainView(registerView, loginView);

            return mainView;
        }
    }
}
