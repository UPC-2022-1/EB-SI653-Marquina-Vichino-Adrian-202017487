using si653ebu202017487.API.MagnetArt.Training.Domain.Models;
using si653ebu202017487.API.MagnetArt.Training.Domain.Services.Communication;


namespace si653ebu202017487.API.MagnetArt.Training.Domain.Services {
	public interface IProviderService {
		Task<Provider> ListByProviderIdAsync(int providerId);
		Task<ProviderResponse> SaveAsync(Provider provider);
	}
}
