using si653ebu202017487.API.MagnetArt.Painting.Domain.Models;

namespace si653ebu202017487.API.MagnetArt.Painting.Domain.Repositories {
	public interface IAuthorRepository {

		Task<IEnumerable<Author>> ListAsync();
		Task AddAsync(Author author);
	}
}
