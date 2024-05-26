using VisitePenacova.Domain.Entities;

namespace VisitePenacova.Application.Common.Interfaces
{
	public interface ILocalRepository : IRepository<Local>
	{
		void Update(Local entity);
		void Save();
	}
}
