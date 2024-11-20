using AceBackend.Application.Queries.GetAllProductPaginated;
using AceBackend.Models.Entities;
using AceBackend.Repositories;
using MediatR;

namespace AceBackend.Services.Queries.GetAllProductPaginated
{
    public class GetAllProductPaginatedQueryHandler : IRequestHandler<GetAllProductPaginatedQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _produitRepository;
        public GetAllProductPaginatedQueryHandler(IProductRepository produitRepository)
        {
            _produitRepository = produitRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductPaginatedQuery request, CancellationToken cancellationToken)
        {
            var produits = await _produitRepository.GetAllAsync();
            return produits;
        }
    }
}
