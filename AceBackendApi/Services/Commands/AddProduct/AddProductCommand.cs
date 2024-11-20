using MediatR;

namespace AceBackend.Application.Commands
{
    public class AddProductCommand : IRequest<Guid>
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public int QuantiteEnStock { get; set; }
        public DateTime DateAjout { get; set; }

        public AddProductCommand(string nom, string description, decimal prix, int quantiteEnStock)
        {
            Nom = nom;
            Description = description;
            Prix = prix;
            QuantiteEnStock = quantiteEnStock;
            DateAjout = DateTime.UtcNow;
        }
    }
}
