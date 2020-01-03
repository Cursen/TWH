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
        public UserManager(UnitOfWork unitOfWork)
        {
            userService = new UserService(unitOfWork);
        }
        public bool Validate(string username)
        {
            if(userService.getByName)
        }
    }
}
