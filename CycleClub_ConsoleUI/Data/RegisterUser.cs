using CycleClub_ConsoleUI.FieldValidators;
using CycleClub_ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub_ConsoleUI.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExists(string emailAddress)
        {
            bool emailExists = false;

            using (var dbContext = new ClubMemberShipDbContext())
            {
                emailExists = dbContext.Users.Any(u => u.EmailAddress.ToLower().Trim() == emailAddress.Trim().ToLower());
            }
            return emailExists;
        }

        public bool Register(string[] fields)
        {
            using (var dbContext = new ClubMemberShipDbContext())
            {
                User user = new User
                {
                    EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    Password = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.EmailAddress]),
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    AddressCity = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                };

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            return true;
        }
    }
}
