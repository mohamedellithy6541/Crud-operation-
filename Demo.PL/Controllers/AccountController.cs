using Demo.Dal.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModeld model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FName = model.Fname,
                    LName = model.Lname,
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    IsAgree = model.IsAgree,
                };

            var resulte=  await _userManager.CreateAsync(user,model.Password);
                if (resulte.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach (var error in resulte.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(model);
        }
        public IActionResult Login() 
        {
            return View();
        
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var user=await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var flag =await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag) 
                    {
                        await _signInManager.PasswordSignInAsync(user,model.Password,model.RememberMe,false);
                        return RedirectToAction("Index","Home");
                    }
                    ModelState.AddModelError(string.Empty, "invalied  user Name and password ");
                }
                ModelState.AddModelError(string.Empty, "invalied Emails");
                
            }

            return View(model);
        }


        public new async Task<IActionResult>SingOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        } 
        public async Task<IActionResult> ForgetPasswod()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }   
        public async Task<IActionResult> SendEmail(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var user =await _userManager.FindByEmailAsync(model.Email);

                if(user is not null)    
                {

                    
                }
                ModelState.AddModelError(string.Empty," EMAIL IS NOT Found");
            }

            return View(model);
        }
    }
}
