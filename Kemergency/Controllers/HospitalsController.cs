using Kemergency.Data;
using Kemergency.Models;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Controllers
{

    public class HospitalsController : Controller
    {

        private ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HospitalsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

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

        public IActionResult Details(int id)
        {

            var hospital = _context.Hospitals.Include(s => s.Status).SingleOrDefault(c => c.Id == id);

            if (hospital == null)
                return ViewBag("NotFound");

            return View(hospital);
        }
        [Authorize]
        public IActionResult BookingEdti(int id)
        {
            var hospital = _context.Hospitals.Include(s => s.Status).Include(h=>h.Hservice).SingleOrDefault(c => c.Id == id);

            //if (hospital == null)
            //    return ViewBag("NotFound");

            var viewModel = new NewHospitalViewModel
            {
               Id=hospital.Id,
               Name = hospital.Name,
               ServicesName = hospital.Hservice.Name,
               Address = hospital.Address,
               NumberOfAmbuliance = hospital.NumberOfAmbuliance,
               Telephone = hospital.Telephone,
              
            };

            return View(viewModel);
        }
        public IActionResult Booking()
        {

            var hospital = _context.Hospitals.Include(s => s.Status);
            var viewmodel = hospital.Select(p => new BookingViewModel
            {
                ServicesName = p.Hservice.Name,
                Id = p.Id,
                HospitalName = p.Name,
                Address = p.Address,
                AvaliableAmbuliance = p.NumberOfAmbuliance,
                HospitalStaus = p.Status.Description,
                Phone = p.Telephone,
                CloseTime = p.ClosDate,
                OpenTime = p.DateOpen,


            }).ToList();

            return View("Services", viewmodel);
        }


        public ActionResult Edit(int id)
        {
            var hospital = _context.Hospitals.Include(s => s.Status).SingleOrDefault(c => c.Id == id);

            if (hospital == null)
                return ViewBag("NotFound");

            var viewModel = new NewHospitalViewModel
            {
                Hospital = hospital,
                hservices = _context.Hservices.ToList(),       
                Statuse = _context.Statuses.ToList(),
            };

            return View("HospitalForm", viewModel);
        }
        public ViewResult Index()
        {
            return View();
        }
    }
}
