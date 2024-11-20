using AceBackend.Application.Commands;
using AceBackend.Models.Entities;
using AceBackend.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AceBackend.Application.Handlers
{
    public class AddProduitCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public AddProduitCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var produit = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Nom = request.Nom,
                Description = request.Description,
                Prix = request.Prix,
                QuantiteEnStock = request.QuantiteEnStock,
                DateAjout = request.DateAjout
            };

            await _productRepository.AddAsync(produit);

            return Guid.Parse(produit.Id);
        }
    }
}
