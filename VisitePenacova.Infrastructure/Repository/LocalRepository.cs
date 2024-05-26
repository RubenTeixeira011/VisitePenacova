using VisitePenacova.Application.Common.Interfaces;
using VisitePenacova.Domain.Entities;
using VisitePenacova.Infrastructure.Data;

namespace VisitePenacova.Infrastructure.Repository
{
	public class LocalRepository : Repository<Local>, ILocalRepository
	{
		private readonly ApplicationDbContext _db;

		public LocalRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		

		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Local entity)
		{
			_db.Update(entity);
		}
	}
}
