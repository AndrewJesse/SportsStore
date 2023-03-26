using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class AccountController : Controller
    {
        // Dependency injection of UserManager and SignInManager
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        // GET method for displaying the login form
        public ViewResult Login(string returnUrl)
        {
            // Passes a new instance of the LoginModel to the view
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        // POST method for handling login form submissions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // Attempts to retrieve the user based on the username entered in the form
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);

                if (user != null)
                {
                    // Signs the user out of any existing sessions
                    await signInManager.SignOutAsync();

                    // Attempts to sign in the user with the provided password
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        // Redirects the user to the Admin page if sign-in succeeds
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin");
                    }
                }

                // Adds an error message to the ModelState if sign-in fails
                ModelState.AddModelError("", "Invalid name or password");
            }

            // Re-renders the login form with error messages if sign-in fails
            return View(loginModel);
        }

        // Logout method that signs the user out and redirects to a specified URL
        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
