using Kemergency.Areas.FireTrackK.Models;
using Kemergency.Bussiness;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Controllers
{
  
    public class FireTrackServiceController : Controller
    {
        private FireTrackServices _context;
        public FireTrackServiceController(FireTrackServices context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var track = _context.GetAll();

            var viemodel = track.Select(f => new FireTrackServiceViewModeel
            {
                Id  = f.Id,
                Name = f.Name,
                Address = f.Address,
                DriverName = f.DriverName,
                DriverNumber = f.DriverNumber,
                phoneNumber = f.phoneNumber,
                 TrackNumber = f.TrackNumber,
            });

            return View(viemodel);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var track = _context.GetById(id);

            return PartialView(track);
        }
      
    }
}
