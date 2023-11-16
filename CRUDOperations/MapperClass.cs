using AutoMapper;
using CRUDOperation.Application.Dtos;
using CRUDOperations.Domain.Models;
using CRUDOperations.Infrastructure.Dtos;
using CRUDOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.Application
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<Brand, BrandCreateDto>().ReverseMap();
            CreateMap<Brand, BrandReadDto>().ReverseMap();
            CreateMap<Brand, BrandUpdateDto>().ReverseMap();
        }
    }
}
