using CRUDOperation.Application.Dtos;
using CRUDOperations.Infrastructure.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.Application.Commands.Request
{
    public class AddBrandRequest: IRequest<ApiResponse>
    {
        public BrandCreateDto? AddBrand { get; set; }
    }
}
