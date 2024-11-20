using AceBackend.Application.Commands;
using AceBackend.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AceBackend.Application.Handlers
{
    public class DeleteProduitCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProduitCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var produit = await _productRepository.GetByIdAsync(request.Id);

            if (produit == null)
            {
                return false; 
            }

            await _productRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
