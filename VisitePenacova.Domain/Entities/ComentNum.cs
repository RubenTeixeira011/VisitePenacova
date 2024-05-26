using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisitePenacova.Domain.Entities
{
    public class ComentNum
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Número do comentário")]
        public int Coment_Num { get; set; }

        [ForeignKey("Local")]
        public int LocalId { get; set; }
        [ValidateNever]
        public Local Local { get; set; } = null!;

		[Display(Name = "Comentário")]
		public string? Comentario { get; set; }
    }
}
