using System;
using System.Collections.Generic;
using System.Text;
using TWH.Repository;
using TWH.Services.Services;

namespace TWH.Services.Managers
{
    public class UserManager
    {
        public UserService userService { get; set; }
        string jwtToken;
        int jwtTimespan;
        public UserManager(UnitOfWork unitOfWork)
        {
            userService = new UserService(unitOfWork);
        }
        
    }
}
