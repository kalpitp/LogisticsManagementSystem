using LogisticsManagement.DataAccess.Models;
using LogisticsManagement.DataAccess.Repository;
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
        private readonly IAuthenticationRepository _repository;

        public AuthenticationServices(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        public  bool Login(string userId, string password)
        {
            // for email validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // check if user id or password is empty
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                 CommonServices.ErrorMessage("User ID or Password can't be empty");
            }

             User user=  _repository.GetUserByUserId(userId);

            if(user != null && user.Password==password)
            {
                return true;
            }
            return false;
        }
    }
}
