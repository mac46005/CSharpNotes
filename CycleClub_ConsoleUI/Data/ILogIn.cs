using CycleClub_ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub_ConsoleUI.Data
{
    public interface ILogIn
    {
        User Login(string emailAddress, string password);
    }
}
