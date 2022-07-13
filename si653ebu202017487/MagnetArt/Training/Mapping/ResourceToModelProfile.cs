using AutoMapper;

using si653ebu202017487.API.MagnetArt.Training.Domain.Models;
using si653ebu202017487.API.MagnetArt.Training.Resources;

namespace si653ebu202017487.API.MagnetArt.Training.Mapping {
	public class ResourceToModelProfile : Profile {
		public ResourceToModelProfile() {
			CreateMap<SaveProviderResource, Provider>();
		}
	}
}
