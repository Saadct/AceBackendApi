using MediatR;
using System.Collections.Generic;
using AceBackend.Models.Entities;

namespace AceBackend.Application.Queries.GetAllProduitsPaginated
{
    public class GetAllProductPaginatedQuery : IRequest<IEnumerable<Product>>
    {
    }
}
