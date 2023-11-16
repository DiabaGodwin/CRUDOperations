using AutoMapper;
using CRUDOperation.Application.Queries.Request;
using MediatR;
using CRUDOperation.Application.Repository;
using CRUDOperation.Application.Dtos;

namespace CRUDOperation.Application.Queries.RequestHandler
{
    public class GetAllBrandRequestHandler : IRequestHandler<GetAllBrandsRequest, IReadOnlyList<BrandReadDto>>
    {
        private readonly IGenericRepository<BrandReadDto> _repo;
        private readonly IMapper _mapper;
        public GetAllBrandRequestHandler(IGenericRepository<BrandReadDto> repo, IMapper mapper) { 
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<BrandReadDto>> Handle(GetAllBrandsRequest request, CancellationToken cancellationToken)
        {
            var response = $"[dbo].[GetAllBrands]";
            var result = await _repo.GetAllAsync(response);
            return _mapper.Map<IReadOnlyList<BrandReadDto>>(result);
        }
    }
}
