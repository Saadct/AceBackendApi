using MediatR;

namespace AceBackend.Application.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public int QuantiteEnStock { get; set; }

        public UpdateProductCommand(string id, string nom, string description, decimal prix, int quantiteEnStock)
        {
            Id = id;
            Nom = nom;
            Description = description;
            Prix = prix;
            QuantiteEnStock = quantiteEnStock;
        }
    }
}
