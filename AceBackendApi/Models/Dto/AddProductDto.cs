using System.ComponentModel.DataAnnotations;

namespace AceBackend.Models.Dto
{
    public class AddProductDto
    {
        [Required(ErrorMessage = "Le nom du produit est requis.")]

        public required string Nom { get; set; }
        public required string Description { get; set; }
       
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0.")]
        public decimal Prix { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La quantité en stock doit être supérieure ou égale à 0.")]
        public int QuantiteEnStock { get; set; }

        [Required(ErrorMessage = "La date d'ajout est requise.")]

        public DateTime DateAjout { get; set; }

    }
}
