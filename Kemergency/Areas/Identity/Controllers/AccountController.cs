
using Kemergency.Data;
using Kemergency.Helpers;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Kemergency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kemergency.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;

 

        public AccountController(ApplicationDbContext context, SignInManager<ApplicationUser> signinManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signinManager = signinManager;
            _userManager = userManager;
        }
        [HttpGet]
        [AllowAnonymous]



        [Route("Identity/Account/Regester")]
        public IActionResult Regester()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Regester(RegisterViewModel ReModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = ReModel.Email,
                    Email = ReModel.Email,
                    Name = ReModel.Name,
                    AppUserId = ReModel.Id,
                    Phone = ReModel.Phone,
                    Address = ReModel.Address,
                    NicNubmer = ReModel.NicNubmer
                };

               




                //int userid = users.Select(c => c.Id).FirstOrDefault();



                var result = await _userManager.CreateAsync(user, ReModel.Password);
                var muser = _userManager.Users.Where(d=>d.Id == user.Id).FirstOrDefault();

                if (result.Succeeded)
                {
                    var cu = new Myusers
                    {
                        Image = ReModel.Image,
                        Id = muser.Id,
                        Name = ReModel.Name,

                        Phone = ReModel.Phone,
                        Address = ReModel.Address,
                        NicNubmer = ReModel.NicNubmer,

                    };

                    _context.Customers.Add(cu);
                    _context.SaveChanges();
                    // If the user is signed in and in the Admin role, then it is
                    // the Admin user that is creating a new user. So redirect the
                    // Admin user to ListRoles action
                    //if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    //{
                    //    return RedirectToAction("ListUsers", "Administration");
                    //}
                    await _signinManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(ReModel);
        }

        [HttpGet]
        [AllowAnonymous]   // allow some one to have access to login page
        [Route("Identity/Account/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]   // returnurl to redirect user to orignal url
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel Lmodel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(Lmodel.Email, Lmodel.Password, Lmodel.RememberMe, false);
                if (result.Succeeded)
                {

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        var user = await _userManager.FindByNameAsync(Lmodel.Email);


                        return LocalRedirect(returnUrl);
                        //return Redirect(returnUrl);
                        // use local redirect to avoid attacks
                    }
                   
                   

                      
                        return RedirectToRoute(new { controller = "Home", action = "Index" });
                    
                }

            }
            ModelState.AddModelError(string.Empty, "Invalid Login");

            return View(Lmodel);

        }



        [Route("Identity/Account/LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _signinManager.SignOutAsync();
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("index", "home");
        }
    }
}
