using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidPaynes.DTOs;
using VidPaynes.Models;

namespace VidPaynes.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customers>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Movie, MoviesDTO>();
            Mapper.CreateMap<MoviesDTO, Movie>();
        }
    }
}