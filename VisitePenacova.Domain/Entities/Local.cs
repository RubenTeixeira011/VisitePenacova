using System.ComponentModel.DataAnnotations;

namespace VisitePenacova.Domain.Entities
{
    public class Local
    {
        public int Id { get; set; }
        [MaxLength(60)]
        public required string Nome { get; set; }
        [Display(Name ="Descrição")]
        public string? Descricao { get; set; }
        public required string Localidade { get; set; }
        public required string Freguesia { get; set; }
        public required string Categoria { get; set; }
        [Display(Name="Imagem Url")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
