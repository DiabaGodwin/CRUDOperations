using AutoMapper;
using CRUDOperation.Application.Commands.Request;
using CRUDOperation.Application.Repository;
using CRUDOperations.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.Application.Commands.RequestHandler
{
    public class DeleteBrandRequestHandler : IRequestHandler<DeleteBrandRequest, ApiResponse>
    {
        private readonly IGenericRepository<Brand> _repository;
        private readonly IMapper _mapper;
        public DeleteBrandRequestHandler(IGenericRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> Handle(DeleteBrandRequest request, CancellationToken cancellationToken)
        {
            FormattableString query = $"[dbo].[spcDeleteBrand] @BrandIdpk={request.Id}";
            var response = await _repository.Delete(query);
            if(response != null)
                return new ApiResponse
                {
                    isSuccess = true,
                    Message = "Record Successfully Deleted"
                };
            return new ApiResponse
            {
                isSuccess = false,
                Message = "Record failed to delete"
            };
        }
    }
}
