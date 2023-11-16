using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.Application.Commands.Request
{
    public class DeleteBrandRequest: IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
