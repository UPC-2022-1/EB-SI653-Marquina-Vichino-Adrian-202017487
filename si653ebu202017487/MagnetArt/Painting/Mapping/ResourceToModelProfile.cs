using AutoMapper;

using si653ebu202017487.API.MagnetArt.Painting.Domain.Models;
using si653ebu202017487.API.MagnetArt.Painting.Resources;

namespace si653ebu202017487.API.MagnetArt.Painting.Mapping {
	public class ResourceToModelProfile : Profile {
		public ResourceToModelProfile() {
			CreateMap<SaveAuthorResource, Author>();
		}
	}
}
