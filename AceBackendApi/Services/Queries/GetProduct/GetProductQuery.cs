using MediatR;
using AceBackend.Models.Entities;

namespace AceBackend.Application.Queries.GetProduit
{
    public class GetProductQuery : IRequest<Product>
    {
        public string Id { get; set; }

        public GetProductQuery(string id)
        {
            Id = id;
        }
    }
}
