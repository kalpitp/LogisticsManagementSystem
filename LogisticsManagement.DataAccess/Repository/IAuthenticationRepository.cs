﻿using LogisticsManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.DataAccess.Repository
{
    public interface IAuthenticationRepository
    {

        //For fetching user for login
        User GetUserByUserId(string userId);
    }
}
