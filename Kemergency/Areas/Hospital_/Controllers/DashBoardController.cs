using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.Hospital_.Controllers
{
    [Area("Hospital_")]
    public class DashBoardController : Controller
    {

        [Route("Hospital_/dashboard/index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
