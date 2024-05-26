using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisitePenacova.Domain.Entities;
using VisitePenacova.Infrastructure.Data;
using VisitePenacova.Web.ViewModels;

namespace VisitePenacova.Web.Controllers
{
    public class ComentNumController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ComentNumController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var comentNums = _db.ComentNums
                .Include(u=>u.Local)
                .ToList();

            return View(comentNums);
        }
        public IActionResult Criar()
        {
            ComentNumVM comentNumVM = new()
            {
                LocalList = _db.Locais.ToList().Select(u => new SelectListItem
                {
                    Text = u.Nome,
                    Value = u.Id.ToString()
                })
            };
			

			return View(comentNumVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(ComentNumVM obj)
        {
            
            bool roomNumberExists = _db.ComentNums.Any(u=>u.Coment_Num == obj.ComentNum.Coment_Num);
                
            if(ModelState.IsValid && !roomNumberExists)
            {
                _db.ComentNums.Add(obj.ComentNum);
                _db.SaveChanges();
                TempData["success"] = "Comentário criado com sucesso.";
                return RedirectToAction(nameof(Index));
            }

            if(roomNumberExists)
            {
				TempData["error"] = "O número do comentário já existe!.";
			}

            obj.LocalList = _db.Locais.ToList().Select(u => new SelectListItem
            {
                Text = u.Nome,
                Value = u.Id.ToString()
            });



			return View(obj);
             
        }
        public IActionResult Editar(int comentNumId) 
        {
			ComentNumVM comentNumVM = new()
			{
				LocalList = _db.Locais.ToList().Select(u => new SelectListItem
				{
					Text = u.Nome,
					Value = u.Id.ToString()
				}),
                ComentNum = _db.ComentNums.FirstOrDefault(_=>_.Coment_Num == comentNumId)!
			};

			if (comentNumVM.ComentNum is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(comentNumVM); 
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Editar(ComentNumVM comentNumVM)
		{

			if (ModelState.IsValid)
			{
				_db.ComentNums.Update(comentNumVM.ComentNum);
				_db.SaveChanges();
				TempData["success"] = "Comentário editado com sucesso.";
				return RedirectToAction(nameof(Index));
			}



			comentNumVM.LocalList = _db.Locais.ToList().Select(u => new SelectListItem
			{
				Text = u.Nome,
				Value = u.Id.ToString()
			});



			return View(comentNumVM);

		}

		public IActionResult Eliminar(int comentNumId)
		{
			ComentNumVM comentNumVM = new()
			{
				LocalList = _db.Locais.ToList().Select(u => new SelectListItem
				{
					Text = u.Nome,
					Value = u.Id.ToString()
				}),
				ComentNum = _db.ComentNums.FirstOrDefault(_ => _.Coment_Num == comentNumId)!
			};

			if (comentNumVM.ComentNum is null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(comentNumVM);
		}
		[HttpPost]
        public IActionResult Eliminar(ComentNumVM comentNumVM)
        {
            ComentNum? objFromDb = _db.ComentNums
                .FirstOrDefault(_=>_.Coment_Num==comentNumVM.ComentNum.Coment_Num);

            if (objFromDb is not null)
            {
                _db.ComentNums.Remove(objFromDb);
                _db.SaveChanges();

                TempData["success"] = "Comentário eliminado com sucesso.";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "Erro ao tentar eliminar o Comentário.";
            return View(comentNumVM);

        }
    }
}
