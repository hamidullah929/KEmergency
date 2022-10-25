
using Kemergency.Bussiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kemergency.Areas.Hospital_.Controllers
{
    [Area("Hospital_")]
    public class DashBoardController : Controller
    {
        private BookingServices _bookinservices;

        public DashBoardController(BookingServices bookinservices)
        {
            _bookinservices = bookinservices;
        }

        [Route("Hospital_/dashboard/index")]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Appointments = _bookinservices.GetAll().Where(i => i.MyusersId == userId).Count();
            return View();
          
        }
    }
}
