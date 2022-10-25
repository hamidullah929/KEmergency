using Kemergency.Bussiness;
using Kemergency.Data;
using Kemergency.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kemergency.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProfileController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private CustomerServices _Cservices;
        private UserManager<ApplicationUser> _userManager;

        public ProfileController(CustomerServices Cservices, IWebHostEnvironment hostEnvironment)
        {
            _Cservices = Cservices;
            _hostEnvironment = hostEnvironment;
        }
        [Route("Customer/Profile/Edit")]
        [HttpGet]
        public IActionResult Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
          // var userName = User.FindFirstValue(ClaimTypes.Name) // will give the user's userName

        // For ASP.NET Core <= 3.1
            //ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            //string userEmail = applicationUser?.Email; // will give the user's Email

            // For ASP.NET Core >= 5.0
            //var userEmail = User.FindFirstValue(ClaimTypes.Email) // will giv
            var cs = _Cservices.GetById(userId);

        
        //https://localhost:44307/
            return View(cs);
        }
        [HttpPost]
        [Route("Customer/Profile/EditUser")]
        public IActionResult EditUser( Myusers editUser)
        {
            //string wwwRootPath = _hostEnvironment.WebRootPath;
            //string fileName = Path.GetFileNameWithoutExtension(editUser.ImageFile.FileName);
            //string extension = Path.GetExtension(editUser.ImageFile.FileName);
            //editUser.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //string path = Path.Combine(wwwRootPath + "/Images/", fileName);
            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
            //    editUser.ImageFile.CopyToAsync(fileStream);
            //}
            if (ModelState.IsValid)
            {

              
                _Cservices.EditUser(editUser);
            }

            return RedirectToAction("Index","Booking");
        }
    }
}
