namespace AceBackend.Models.Entities
{
    public class Product : BaseEntity
    {
        public required string Nom { get; set; }
        public required string Description { get; set; }
        public decimal Prix { get; set; }
        public int QuantiteEnStock { get; set; }
        public DateTime DateAjout { get; set; }

    }
}
