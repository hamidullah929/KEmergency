//using AutoMapper;
//using Kemergency.Data;
//using Kemergency.Dtos;
//using Kemergency.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Kemergency.Controllers.Api
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class NewRentalsController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;
//        private IMapper Mapper;

//        public NewRentalsController(ApplicationDbContext context, IMapper _Mapper)
//        {
//            _context = context;
//            Mapper = _Mapper;
//        }

//        public async Task<ActionResult<NewRentalDto>> CreateNewRentals(NewRentalDto newRental)
//        {
//            var customer = _context.Customers.Single(
//                c => c.Id == newRental.CustomerId);

//            //var hospital = _context.Hospitals.Where(
//            //    m => newRental.HospitalId.Contains(m.Id)).ToList();

//            foreach (var hs in hospital)
//            {
//                //if (hs.Hservice.AvaliableAmbuliance == 0)
//                //    return BadRequest("Ambulance is not available.");

//                //hs.Hservice.AvaliableAmbuliance--;

//                //var rental = new Rental
//                //{
//                //    Customer = customer,
//                //    Hospital = hs,
//                //    DateRented = DateTime.Now
//                //};

//                //_context.Rentals.Add(rental);
//            }

//            _context.SaveChanges();

//            return Ok();
//        }
//    }
//}
