using Microsoft.EntityFrameworkCore;

using si653ebu202017487.API.MagnetArt.Painting.Domain.Models;
using si653ebu202017487.API.MagnetArt.Painting.Domain.Repositories;
using si653ebu202017487.API.Shared.Persistence.Contexts;
using si653ebu202017487.API.Shared.Persistence.Repositories;
using si653ebu202017487.Shared.Persistence.Repositories;

namespace si653ebu202017487.API.MagnetArt.Painting.Persistence.Repositories {
	public class AuthorRepository : BaseRepository, IAuthorRepository {
		public AuthorRepository(AppDbContext context) : base(context) {
		}
		
		public async Task<IEnumerable<Author>> ListAsync() {
			return await _context.Authors.ToListAsync();
		}

		public async Task AddAsync(Author author) {
			await _context.Authors.AddAsync(author);
		}
		
	}
}