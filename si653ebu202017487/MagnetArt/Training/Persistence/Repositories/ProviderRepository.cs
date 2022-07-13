using Microsoft.EntityFrameworkCore;

using si653ebu202017487.API.MagnetArt.Training.Domain.Models;
using si653ebu202017487.API.MagnetArt.Training.Domain.Repositories;
using si653ebu202017487.API.Shared.Persistence.Contexts;
using si653ebu202017487.API.Shared.Persistence.Repositories;
using si653ebu202017487.Shared.Persistence.Repositories;

namespace si653ebu202017487.API.MagnetArt.Training.Persistence.Repositories {
	public class ProviderRepository : BaseRepository, IProviderRepository {
		public ProviderRepository(AppDbContext context) : base(context) {
		}
		
		public async Task<Provider> FindByProviderIdAsync(int providerId) {
			return await _context.Providers.FindAsync(providerId);
		}

		public async Task AddAsync(Provider provider) {
			await _context.Providers.AddAsync(provider);
		}
		
	}
}