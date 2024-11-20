namespace AceBackend.Models.Dto
{
    public class UpdateProductDto
    {
        public required string Id { get; set; }
        public required string Nom { get; set; }
        public required string Description { get; set; }
        public decimal Prix { get; set; }
        public int QuantiteEnStock { get; set; }
        public DateTime DateAjout { get; set; }

    }
}
