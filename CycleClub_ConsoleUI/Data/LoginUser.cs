using CycleClub_ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub_ConsoleUI.Data
{
    public class LoginUser : ILogIn
    {
        public User Login(string emailAddress, string password)
        {
            User user = null;
            using(var dbContext = new ClubMemberShipDbContext())
            {
                user = dbContext.Users.FirstOrDefault(u => u.EmailAddress == emailAddress && u.Password == password);

            }
            return user;
        }
    }
}
