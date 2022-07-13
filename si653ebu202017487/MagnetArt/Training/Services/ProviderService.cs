using si653ebu202017487.API.MagnetArt.Training.Domain.Models;
using si653ebu202017487.API.MagnetArt.Training.Domain.Repositories;
using si653ebu202017487.API.MagnetArt.Training.Domain.Services;
using si653ebu202017487.API.MagnetArt.Training.Domain.Services.Communication;
using si653ebu202017487.API.Shared.Domain.Repositories;

namespace si653ebu202017487.API.MagnetArt.Training.Services {
	public class ProviderService : IProviderService {
		private readonly IProviderRepository _providerRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ProviderService(IProviderRepository providerRepository, IUnitOfWork unitOfWork) {
			_providerRepository = providerRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Provider> ListByProviderIdAsync(int providerId) {
			return await _providerRepository.FindByProviderIdAsync(providerId);
		}

		public async Task<ProviderResponse> SaveAsync(Provider provider) {
			try {
				await _providerRepository.AddAsync(provider);
				await _unitOfWork.CompleteAsync();
				return new ProviderResponse(provider);
			} catch (Exception e) {
				return new ProviderResponse($"An error occurred while saving the provider: {e.Message}");
			}
		}

	}
}
