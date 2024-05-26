namespace VisitePenacova.Application.Common.Interfaces
{
	public interface IUnitOfWork
	{
		ILocalRepository Local {  get; }
	}
}
