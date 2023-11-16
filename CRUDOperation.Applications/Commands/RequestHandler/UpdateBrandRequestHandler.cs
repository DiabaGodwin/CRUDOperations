using AutoMapper;
using CRUDOperation.Application.Commands.Request;
using CRUDOperation.Application.Dtos;
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
    internal class UpdateBrandRequestHandler : IRequestHandler<UpdateBrandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<BrandUpdateDto> _repo;
        public UpdateBrandRequestHandler(IGenericRepository<BrandUpdateDto> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateBrandRequest request, CancellationToken cancellationToken)
        {
            var dto = request.Update;
            var entity = new Brand();
            _mapper.Map(dto, entity);
            FormattableString query = $"[dbo].[spcUpdateBrand] @Name={entity.Name}, @Category={entity.Category}, @isActive={entity.IsActive}, @BrandIdpk ={request.Id}";
            var response = await _repo.Update(query);
            return Unit.Value;
        }
    }
}
