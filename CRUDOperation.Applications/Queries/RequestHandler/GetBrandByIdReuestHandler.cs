using AutoMapper;
using CRUDOperation.Application.Dtos;
using CRUDOperation.Application.Queries.Request;
using CRUDOperation.Application.Repository;
using MediatR;

namespace CRUDOperation.Application.Queries.RequestHandler
{
    public class GetBrandByIdReuestHandler : IRequestHandler<GetBrandByIdRequest, BrandReadDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<BrandReadDto> _repo;
        public GetBrandByIdReuestHandler(IMapper mapper, IGenericRepository<BrandReadDto> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<BrandReadDto> Handle(GetBrandByIdRequest request, CancellationToken cancellationToken)
        {
            FormattableString response = $"[dbo].[GetBrand] @brand_Id = {request.Id}";
            var result = await _repo.GetBrandById(response);
            return _mapper.Map<BrandReadDto>(result);
        }
    }
}
