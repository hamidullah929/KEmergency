using Kemergency.Bussiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.FireTrackK.Controllers
{
    public class FireTrackController : Controller
    {
        private FireTrackServices _context;
        public FireTrackController(FireTrackServices context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var racmodel = _context.GetAll();
            return View("~/");
        }
    }
}
