using AceBackend.Application.Commands;
using AceBackend.Models.Entities;
using AceBackend.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AceBackend.Application.Handlers
{
    public class UpdateProduitCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProduitCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var produit = await _productRepository.GetByIdAsync(request.Id);

            if (produit == null)
            {
                return false; 
            }

            produit.Nom = request.Nom;
            produit.Description = request.Description;
            produit.Prix = request.Prix;
            produit.QuantiteEnStock = request.QuantiteEnStock;

            await _productRepository.UpdateAsync(produit);

            return true;
        }
    }
}
