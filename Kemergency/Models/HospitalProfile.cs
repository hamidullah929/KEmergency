using AutoMapper;
using Kemergency.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Models
{
    public class HospitalProfile:Profile
    {
        public HospitalProfile()
        {
            // Domain to Dto
            CreateMap<Hospital, HospitalDto>();
          //  Mapper.CreateMap<Movie, MovieDto>();
            CreateMap<Hservice, HopitalServicesDto>();
            //Mapper.CreateMap<Genre, GenreDto>();


            // Dto to Domain
            CreateMap<HospitalDto, Hospital>()
                .ForMember(c => c.Id, opt => opt.Ignore());

           //.. Mapper.CreateMap<MovieDto, Movie>()
            //   .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
