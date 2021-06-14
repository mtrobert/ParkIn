using AutoMapper;
using ParkInAPI.Models;
using ParkInAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkInAPI.ParkInMapper
{
    public class ParkInMappings : Profile
    {
        public ParkInMappings()
        {
            CreateMap<NationalPark, NationalParkDTO>().ReverseMap();
        }
    }
}
