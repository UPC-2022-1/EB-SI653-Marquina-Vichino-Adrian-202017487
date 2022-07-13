using si653ebu202017487.API.Shared.Domain.Repositories;
using si653ebu202017487.API.Shared.Persistence.Contexts;

namespace si653ebu202017487.Shared.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork {
	private readonly AppDbContext _context;

	public UnitOfWork(AppDbContext context) {
		_context = context;
	}

	public async Task CompleteAsync() {
		await _context.SaveChangesAsync();
	}
}