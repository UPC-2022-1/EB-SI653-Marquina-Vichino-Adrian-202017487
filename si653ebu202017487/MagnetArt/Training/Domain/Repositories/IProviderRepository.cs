using si653ebu202017487.API.MagnetArt.Training.Domain.Models;

namespace si653ebu202017487.API.MagnetArt.Training.Domain.Repositories {
	public interface IProviderRepository {
		Task AddAsync(Provider author);
		Task<Provider> FindByProviderIdAsync(int providerId);
	}
}
