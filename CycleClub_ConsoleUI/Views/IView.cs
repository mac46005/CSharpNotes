using CycleClub_ConsoleUI.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub_ConsoleUI.Views
{
    public interface IView
    {
        void RunView();

        IFieldValidator FieldValidator { get;  }
    }
}
