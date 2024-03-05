using LogisticsManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.DataAccess.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly CybageLogisticsContext _context;

        public AuthenticationRepository(CybageLogisticsContext dbContext)
        {
            _context = dbContext;
        }


        public User GetUserByUserId(string userId)
        {
           return  _context.Users.FirstOrDefault(u=>u.Email== userId);
        }
    }
}
