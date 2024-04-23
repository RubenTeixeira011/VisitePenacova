namespace VisitePenacova.Domain.Entities
{
    public class Local
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public required string Localidade { get; set; }
        public required string Freguesia { get; set; }
        public required string Categoria { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
