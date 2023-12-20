using Demo.Dal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using NuGet.Versioning;

namespace Demo.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string searchValue = "")
        {

            if (string.IsNullOrEmpty(searchValue))
            {
                var users = _userManager.Users.ToList();
                return View(users);
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(searchValue);

                if (user != null)
                {
                    return View(new List<ApplicationUser> { user });
                }
                else
                {
                    var users = await _userManager.Users.ToListAsync(); // Get all users
                    return View(users);
                }



            }
        }


        public async Task<IActionResult> Details(string Id)
        {
            if (Id is null)
            {
                return NotFound();
            }
            var s = await _userManager.FindByIdAsync(Id);
            if (s is null)
                return NotFound();
            return View(s);
        }

        public async Task< IActionResult> Edite(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edite(string id, ApplicationUser app)
        {
            if (id != app.Id)
            return  BadRequest();

            if (ModelState.IsValid)
            {
                try
                { 
                    var user = await _userManager.FindByIdAsync(id);
                    user.UserName = app.UserName;
                    user.NormalizedUserName = app.NormalizedUserName.ToUpper();
                    user.LName=app.LName;
                    user.FName = app.FName;
                    user.Email = app.Email;
                    user.NormalizedEmail= app.NormalizedEmail;
                    user.PasswordHash = app.PasswordHash;
                    user.PhoneNumber=app.PhoneNumber;
                    user.IsAgree = app.IsAgree;
                    var resulte = await _userManager.UpdateAsync(user);
                    if (resulte.Succeeded)
                        return RedirectToAction(nameof(Index));
                    foreach (var error in resulte.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (Exception ex)
                {

                    throw ex; 
                }    
                
              }
             return View(app);
        }



    }




    }

