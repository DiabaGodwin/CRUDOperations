using CRUDOperation.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.Application.Queries.Request
{
    public class GetBrandByIdRequest: IRequest<BrandReadDto>
    {
        public int Id { get; set; }
    }
}
