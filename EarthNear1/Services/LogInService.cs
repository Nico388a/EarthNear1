using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarthNear1.Models;

namespace EarthNear1.Services
{
    public class LogInService
    {
        private User _loggedInUser;

        public void UserLogIn(User user)
        {
            _loggedInUser = user;
        }
        public void UserLogOut()
        {
            _loggedInUser = null;
        }
        public User GetLoggedUser()
        {
            return _loggedInUser;
        }
    }
}
