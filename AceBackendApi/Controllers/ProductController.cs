using AceBackend.Application.Commands;
using AceBackend.Application.Queries.GetAllProduitsPaginated;
using AceBackend.Application.Queries.GetProduit;
using AceBackend.Models.Dto;
using AceBackend.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AceBackend.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/products?page=1&pageSize=10  TODO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {

            /*
            if (page <= 0 || pageSize <= 0)
                return BadRequest(new { message = "Page et PageSize doivent être supérieurs à 0." });
            */

            var query = new GetAllProductPaginatedQuery();

            var products = await _mediator.Send(query);

            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById([FromRoute] string id)
        {
            var product = await _mediator.Send(new GetProductQuery(id));

            if (product == null)
                return NotFound(new { message = "Produit introuvable." });

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<AddProductDto>> AddProduct([FromBody] AddProductDto addProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new AddProductCommand
            (
                addProductDto.Nom,
                addProductDto.Description,
                addProductDto.Prix,
                addProductDto.QuantiteEnStock
            );

            var product = await _mediator.Send(command);

            return StatusCode(201, product);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != updateProductDto.Id)
                return BadRequest(new { message = "L'ID dans l'URL ne correspond pas à celui de la commande." });

            var command = new UpdateProductCommand
            (
                updateProductDto.Id,
                updateProductDto.Nom,
                updateProductDto.Description,
                updateProductDto.Prix,
                updateProductDto.QuantiteEnStock
            );

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound(new { message = "Produit introuvable pour la mise à jour." });

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));

            if (!result)
                return NotFound(new { message = "Produit introuvable pour la suppression." });

            return NoContent();
        }
    }
}
