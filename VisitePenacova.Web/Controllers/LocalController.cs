using Microsoft.AspNetCore.Mvc;
using VisitePenacova.Application.Common.Interfaces;
using VisitePenacova.Domain.Entities;

namespace VisitePenacova.Web.Controllers
{
	public class LocalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocalController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var locais = _unitOfWork.Local.GetAll();

            return View(locais);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Local obj)
        {
            if(obj.Nome == obj.Descricao)
            {
                ModelState.AddModelError("Nome", "A descrição não pode ser igual ao nome.");
            }
            if(ModelState.IsValid)
            {
				_unitOfWork.Local.Add(obj);
				_unitOfWork.Local.Save();
                TempData["success"] = "Local criado com sucesso.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "Erro ao tentar criar o local.";
            return View(obj);
             
        }
        public IActionResult Editar(int localId) 
        { 
            Local? obj = _unitOfWork.Local.Get(_=>_.Id == localId);

			//Local? obj2 = _db.Locais.Find(localId);
			//var LocalLista = _db.Locais.Where(_ => _.Id>1 && _.Id<4);

            if(obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj); 
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Editar(Local obj)
		{
			
			if (ModelState.IsValid && obj.Id>0)
			{
				_unitOfWork.Local.Update(obj);
				_unitOfWork.Local.Save();
                TempData["success"] = "Local editado com sucesso.";
                return RedirectToAction(nameof(Index));
			}

            TempData["error"] = "Erro ao tentar editar o local.";
            return View(obj);

		}

		public IActionResult Eliminar(int localId)
		{
			Local? obj = _unitOfWork.Local.Get(_ => _.Id == localId);


			if (obj is null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(obj);
		}
        [HttpPost]
        public IActionResult Eliminar(Local obj)
        {
            Local? objFromDb = _unitOfWork.Local.Get(_=>_.Id==obj.Id);

            if (objFromDb is not null)
            {
				_unitOfWork.Local.Remove(objFromDb);
				_unitOfWork.Local.Save();

                TempData["success"] = "Local eliminado com sucesso.";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "Erro ao tentar eliminar o local.";
            return View(obj);

        }
    }
}
