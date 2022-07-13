using si653ebu202017487.API.MagnetArt.Training.Domain.Models;
using si653ebu202017487.API.MagnetArt.Training.Resources;
using AutoMapper;

namespace si653ebu202017487.API.MagnetArt.Training.Mapping {
	public class ModelToResourceProfile : Profile {
		public ModelToResourceProfile() {
			CreateMap<Provider, ProviderResource>();
		}
	}
}
