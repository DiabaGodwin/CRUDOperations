using AutoMapper;
using CRUDOperation.Application.Commands.Request;
using CRUDOperation.Application.Dtos;
using CRUDOperation.Application.Repository;
using CRUDOperations.Domain.Models;
using CRUDOperations.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.Application.Commands.RequestHandler
{
    public class AddBrandRequestHandler : IRequestHandler<AddBrandRequest, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Brand> _repo;
        public AddBrandRequestHandler(IMapper mapper, IGenericRepository<Brand> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        //public async Task<int> Handle(AddBrandRequest request, CancellationToken cancellationToken)
        public async Task<ApiResponse> Handle(AddBrandRequest request, CancellationToken cancellationToken)
        { 
            var dto = request.AddBrand;
            var entity = new Brand();
            var data = _mapper.Map(dto, entity);
            FormattableString query = $"[dbo].[spcCreateBrand] @Name = {data.Name}, @Category = {data.Category}, @IsActive = {data.IsActive}";
            var response = await _repo.Insert(query);
            if (response > 0)
                return new ApiResponse
                {
                    isSuccess = true,
                    Message = "Record Successfully Inserted"
                };
            return new ApiResponse
            {
                isSuccess = false,
                Message = "Record failed to save"
            };
        }
    }
}
