using LogisticsManagement.DataAccess.Models;
using LogisticsManagement.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogisticsManagement.Services.Service
{
    public class AuthenticationServices : IAuthenticationServices
    {
        public void Login(string userId, string password)
        {
            // for email validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // check if user id or password is empty
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                 CommonServices.ErrorMessage("User ID or Password can't be empty");
            }

            // check if email is valid
            if (!Regex.IsMatch(userId, pattern))
            {
                CommonServices.ErrorMessage("Enter valid User Id!!");
            }
        }
    }
}
