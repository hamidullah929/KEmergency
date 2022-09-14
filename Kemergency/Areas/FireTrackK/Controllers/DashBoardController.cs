using Kemergency.Bussiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.FireTrackK.Controllers
{
    [Area("FireTrackK")]
    public class DashBoardController : Controller
    {
        FireTrackBookingServices _context;

        public DashBoardController(FireTrackBookingServices context)
        {
            _context = context;
        }
        [Route("FireTrackK/DashBoard/index")]
        public IActionResult Index()
        {
         
            ViewBag.Appointments = _context.getAll().Count();
            return View();
           
        }
    }
}
