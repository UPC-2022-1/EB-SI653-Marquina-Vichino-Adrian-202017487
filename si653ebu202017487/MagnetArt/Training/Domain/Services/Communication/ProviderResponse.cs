using si653ebu202017487.API.MagnetArt.Training.Domain.Models;
using si653ebu202017487.API.Shared.Domain.Services.Communication;

namespace si653ebu202017487.API.MagnetArt.Training.Domain.Services.Communication {
	public class ProviderResponse : BaseResponse<Provider> {
		public ProviderResponse(string message) : base(message) {
		}

		public ProviderResponse(Provider resource) : base(resource) {
		}
	}
}
