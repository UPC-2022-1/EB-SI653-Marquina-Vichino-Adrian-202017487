using si653ebu202017487.API.MagnetArt.Painting.Domain.Models;
using si653ebu202017487.API.MagnetArt.Painting.Domain.Repositories;
using si653ebu202017487.API.MagnetArt.Painting.Domain.Services;
using si653ebu202017487.API.MagnetArt.Painting.Domain.Services.Communication;
using si653ebu202017487.API.MagnetArt.Painting.Persistence.Repositories;
using si653ebu202017487.API.Shared.Domain.Repositories;

namespace si653ebu202017487.API.MagnetArt.Painting.Services {
	public class AuthorService : IAuthorService {
		private readonly IAuthorRepository _authorRepository;
		private readonly IUnitOfWork _unitOfWork;

		public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork) {
			_authorRepository = authorRepository;
			_unitOfWork = unitOfWork;
		}
		
		public async Task<IEnumerable<Author>> ListAsync() {
			return await _authorRepository.ListAsync();
		}

		public async Task<AuthorResponse> SaveAsync(Author author) {
			try {
				System.Diagnostics.Debug.WriteLine(author);
				await _authorRepository.AddAsync(author);
				await _unitOfWork.CompleteAsync();
				return new AuthorResponse(author);
			} catch (Exception e) {
				return new AuthorResponse($"An error occurred while saving the author: {e.Message}");
			}
		}

	}
}
