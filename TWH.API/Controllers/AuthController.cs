using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWH.Entities.DBConfig;
using TWH.Entities.Models;

namespace TWH.API.Controllers
{
    //For reference on this code https://sagarjaybhay.com/how-to-use-usermanager-and-signinmanager-in-asp-net-core-identity/
    //TODO fix so that all the methods here return proper values for the frontends.
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private ILogger logger;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //https://sagarjaybhay.com/basic-role-based-authorization-in-asp-net-core-2019/
        //TODO make it so that the admin can register users. Other not.
        public async Task<ActionResult> Register(string userName, string password)
        {
            var user = new User() { UserName = userName };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                //false name = isPersistent.
                await signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //TODO fix error if registration failed
                return RedirectToAction("Index", "NotHome");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult LogOff()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<string> LogIn(string userName, string password)
        {
            var user = await userManager.FindByNameAsync(userName);
            var result = await signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
               
            }
            else
            {

            }
            return "";
        }
        //https://sagarjaybhay.com/how-to-delete-identity-user-in-asp-net-core-2019/
        //delete user

        //https://sagarjaybhay.com/how-to-edit-the-user-information-in-asp-net-core-vs-2-1/
        //edit user
        private string GenerateToken(User user, string password)
        {
            return Token.GenerateToken(user.UserName);
        }
    }
}
