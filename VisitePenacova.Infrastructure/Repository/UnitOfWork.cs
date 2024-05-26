using VisitePenacova.Application.Common.Interfaces;
using VisitePenacova.Infrastructure.Data;

namespace VisitePenacova.Infrastructure.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;
		public ILocalRepository Local {  get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Local = new LocalRepository(db);
        }
    }
}
