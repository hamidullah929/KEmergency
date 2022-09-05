using Kemergency.Areas.FireTrackK.Models;
using Kemergency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{

    public class FireTrackServices
    {
        private readonly ApplicationDbContext _context;

        public FireTrackServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public FireTrack GetById(int id)
        {
            return _context.FireTracks.Where(f => f.Id == id).SingleOrDefault();
        }

        public IEnumerable<FireTrack> GetAll()
        {
            return _context.FireTracks;
        }

    
    }
}
