using CRUDOperation.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.Application.Commands.Request
{
    public class UpdateBrandRequest :IRequest<Unit>
    {
        public int Id { get; set; }
        public BrandUpdateDto? Update { get; set; }
    }
}
