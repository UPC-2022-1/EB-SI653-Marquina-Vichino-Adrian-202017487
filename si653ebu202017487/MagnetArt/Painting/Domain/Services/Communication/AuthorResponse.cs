using si653ebu202017487.API.MagnetArt.Painting.Domain.Models;
using si653ebu202017487.API.Shared.Domain.Services.Communication;

namespace si653ebu202017487.API.MagnetArt.Painting.Domain.Services.Communication {
	public class AuthorResponse : BaseResponse<Author> {
		public AuthorResponse(string message) : base(message) {
		}

		public AuthorResponse(Author resource) : base(resource) {
		}
	}
}
