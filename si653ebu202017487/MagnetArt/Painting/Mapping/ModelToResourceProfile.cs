using si653ebu202017487.API.MagnetArt.Painting.Domain.Models;
using si653ebu202017487.API.MagnetArt.Painting.Resources;
using AutoMapper;

namespace si653ebu202017487.API.MagnetArt.Painting.Mapping {
	public class ModelToResourceProfile : Profile {
		public ModelToResourceProfile() {
			CreateMap<Author, AuthorResource>();
		}
	}
}
