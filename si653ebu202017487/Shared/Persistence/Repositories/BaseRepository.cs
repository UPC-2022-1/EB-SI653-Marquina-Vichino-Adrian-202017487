namespace si653ebu202017487.API.Shared.Persistence.Repositories;

using si653ebu202017487.API.Shared.Persistence.Contexts;

public class BaseRepository {
	protected readonly AppDbContext _context;

	public BaseRepository(AppDbContext context) {
		_context = context;
	}
}