using MediatR;
using AceBackend.Repositories;
using AceBackend.Models.Entities;
using System.Threading;
using System.Threading.Tasks;
using AceBackend.Application.Queries.GetProduit;

namespace AceBackend.Application.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IProductRepository _produitRepository;

        public GetProductQueryHandler(IProductRepository produitRepository)
        {
            _produitRepository = produitRepository;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var produit = await _produitRepository.GetByIdAsync(request.Id);
            return produit;
        }
    }
}
