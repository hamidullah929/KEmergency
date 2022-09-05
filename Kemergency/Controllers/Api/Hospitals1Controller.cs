//using AutoMapper;
//using Kemergency.Data;
//using Kemergency.Dtos;
//using Kemergency.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Kemergency.Controllers.Api
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class HospitalsController : ControllerBase
//    {

//        private ApplicationDbContext _context;

//        public HospitalsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        // GET: api/<HospitalsController>
//        [HttpGet]
//        public IActionResult GetHospital(string query = null)
//        {
//            var hopitalquerys = _context.Hospitals
//                  .Include(c => c.Hservices);

//            if (!string.IsNullOrWhiteSpace(query))
//                hopitalquerys = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Hospital, Hservice>)hopitalquerys.Where(c => c.Name.Contains(query));

//            var hospitalDtos = hopitalquerys
//                .ToList().Select(Mapper.Map<Hospital, HospitalDto>);//Mapper.Map<Hospital, HospitalDto>);

//            return Ok(hospitalDtos);
//        }

//        // GET api/<HospitalsController>/5
//      //  [HttpGet("{id}")]
//        public IActionResult GetHospital(int id)
//        {
//            var hospital = _context.Hospitals.SingleOrDefault(c => c.Id == id);

//            if (hospital == null)
//                return NotFound();

//            return Ok(Mapper.Map<Hospital,HospitalDto>(hospital));
//        }

//        // POST api/<HospitalsController>
//        [HttpPost]
//        public void CreateCustomer([FromBody] string value)
//        {
//        }

//        // PUT api/<HospitalsController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<HospitalsController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
