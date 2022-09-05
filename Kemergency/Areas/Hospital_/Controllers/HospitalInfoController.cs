using Kemergency.Data;
using Kemergency.Models;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.Hospital_.Controllers
{
    [Area("Hospital_")]
    public class HospitalInfoController : Controller
    {

        private ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HospitalInfoController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        [Route("Hospital_/HospitalInfo/New")]
        public ActionResult New()
        {
            var hospitalsServices = _context.Hservices.ToList();
            var hospitalStatus = _context.Statuses.ToList();

            var viewModel = new NewHospitalViewModel
            {
                Hospital = new Hospital(),
                hservices = hospitalsServices,
                Statuse = hospitalStatus,



            };

            return View("HospitalForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Hospital_/HospitalInfo/Save")]
        public ActionResult Save(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewHospitalViewModel
                {
                    Hospital = hospital,
                    hservices = _context.Hservices.ToList(),
                    Statuse = _context.Statuses.ToList(),


                };

                return View("HospitalForm", viewModel);
            }
            if (hospital.Id == 0)
                //    string wwwRootPath = _hostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                //string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                //imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    await imageModel.ImageFile.CopyToAsync(fileStream);
                //}
                ////Insert record
                //_context.Add(imageModel);
                _context.Hospitals.Add(hospital);
            else
            {
                var customerInDb = _context.Hospitals.Single(c => c.Id == hospital.Id);
                customerInDb.Name = hospital.Name;
                customerInDb.Address = hospital.Address;

                customerInDb.Image = hospital.Image;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Hospitals");
        }
        public IActionResult Index()
        {
            return View();
        }



    }
}
