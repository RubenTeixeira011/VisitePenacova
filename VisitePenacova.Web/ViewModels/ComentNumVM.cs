using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using VisitePenacova.Domain.Entities;

namespace VisitePenacova.Web.ViewModels
{
	public class ComentNumVM
	{
        public ComentNum ComentNum { get; set; } = null!;

        [ValidateNever]
        public IEnumerable<SelectListItem>? LocalList { get; set; }
    }
}
