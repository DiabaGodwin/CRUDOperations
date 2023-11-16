using AutoMapper;
using CRUDOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperations.Application
{
    public class AutoMapperClass: Profile
    {
      public AutoMapperClass() {
           // CreateMap<Brand, BrandCreatDto>().ReverseMap();
        }
    }
}
