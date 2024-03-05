using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.Services.Interface
{
    public interface IAuthenticationServices
    {

        bool Login(string userid, string password);

    }
}
