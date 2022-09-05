using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kemergency.Data;
using Kemergency.Models;
using AutoMapper;
using Kemergency.Dtos;

namespace Kemergency.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper Mapper;
      
        public HospitalsController(ApplicationDbContext context, IMapper _Mapper)
        {
            _context = context;
            Mapper = _Mapper;
        }

        // GET: api/Hospitals
        [HttpGet]
        public async Task<ActionResult> GetHospitals(string query = null)
        {
            var hopitalquerys = _context.Hospitals
                  .Include(c => c.Hservice);

            if (!string.IsNullOrWhiteSpace(query))
                hopitalquerys = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Hospital, Hservice>)hopitalquerys.Where(c => c.Name.Contains(query));

            var hospitalDtos = hopitalquerys
                 .ToList().Select(Mapper.Map<Hospital, HospitalDto>);//Mapper.Map<Hospital, HospitalDto>);

            return Ok(hospitalDtos);
        }

        // GET: api/Hospitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital>> GetHospital(int id)
        {
            var hospital = _context.Hospitals.SingleOrDefault(c => c.Id == id);

            if (hospital == null)
                return NotFound();

            return Ok(Mapper.Map<Hospital, HospitalDto>(hospital));
        }

        // PUT: api/Hospitals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHospital(int id, Hospital hospital)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hospitalInDb = _context.Hospitals.SingleOrDefault(c => c.Id == id);

            if (hospitalInDb == null)
                return NotFound();

           // Mapper.Map(HospitalDto, Hospital);

            _context.SaveChanges();


            return Ok();
        }

        // POST: api/Hospitals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hospital>> CreateHospital(HospitalDto hospitalDto)
        {
            if (!ModelState.IsValid)

                return BadRequest();

            var hospital = Mapper.Map<HospitalDto, Hospital>(hospitalDto);

            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
            hospitalDto.Id = hospital.Id;

            return CreatedAtAction("GetHospital", new { id = hospital.Id }, hospitalDto);
        }

        // DELETE: api/Hospitals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            var hospitalInDb = _context.Hospitals.SingleOrDefault(c => c.Id == id);

            if (hospitalInDb == null)
                return NotFound();

            _context.Hospitals.Remove(hospitalInDb);
            _context.SaveChanges();

            return Ok();
        }

        private bool HospitalExists(int id)
        {
            return _context.Hospitals.Any(e => e.Id == id);
        }
    }
}
