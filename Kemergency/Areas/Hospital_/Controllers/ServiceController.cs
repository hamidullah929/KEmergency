using Kemergency.Bussiness;
using Kemergency.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.Hospital_.Controllers
{
    [Area("Hospital_")]
    public class ServiceController : Controller
    {
        private AmbulanceServices _aService;
        public ServiceController(AmbulanceServices aService)
        {
            _aService = aService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Hospital_/Service/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Hospital_/Service/Create")]
        public async Task< IActionResult> CreateService(Hservice newService)
        {
            if(ModelState.IsValid)
            {
                _aService.Add(newService);
                ViewBag.Mymessage = "success";
            }


            return RedirectToAction("CreateService");

        }
    }
}
