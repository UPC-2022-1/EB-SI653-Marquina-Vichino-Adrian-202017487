using si653ebu202017487.API.MagnetArt.Painting.Domain.Models;
using si653ebu202017487.API.MagnetArt.Painting.Domain.Services.Communication;


namespace si653ebu202017487.API.MagnetArt.Painting.Domain.Services {
	public interface IAuthorService {
		Task<IEnumerable<Author>> ListAsync();
		Task<AuthorResponse> SaveAsync(Author author);
	}
}
