namespace si653ebu202017487.API.Shared.Domain.Repositories;

public interface IUnitOfWork {
	Task CompleteAsync();
}
