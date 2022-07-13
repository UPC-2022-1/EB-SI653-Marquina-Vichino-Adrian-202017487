using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using si653ebu202017487.API.MagnetArt.Painting.Domain.Models;
using si653ebu202017487.API.MagnetArt.Painting.Domain.Services;
using si653ebu202017487.API.MagnetArt.Painting.Resources;
using si653ebu202017487.API.Shared.Extensionss;

using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu202017487.API.MagnetArt.Painting.Controllers {
	[Produces("application/json")]
	[ApiController]
	[Route("/api/v1/[controller]")]
	public class AuthorsController : ControllerBase {
		private readonly IAuthorService _authorService;
		private readonly IMapper _mapper;

		
		public AuthorsController(IAuthorService authorService, IMapper mapper) {
			_authorService = authorService;
			_mapper = mapper;
		}



		/// <summary>
		/// List all authors
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(AuthorResource), 200)]
		[ProducesResponseType(500)]
		[Produces("application/json")]
		[ProducesResponseType(typeof(IEnumerable<AuthorResource>), 200)]
		[SwaggerResponse(200, "The authors were successfully retrieve.", typeof(IEnumerable<AuthorResource>))]
		public async Task<IActionResult> GetAllAsync() {
			var authors = await _authorService.ListAsync();
			var resources = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorResource>>(authors);

			return Ok(resources);

		}


		/// <summary>
		/// Create an author
		/// </summary>
		[HttpPost]
		[ProducesResponseType(typeof(AuthorResource), 201)]
		[ProducesResponseType(typeof(List<string>), 400)]
		[ProducesResponseType(500)]
		[Consumes("application/json")]
		[Produces("application/json")]
		[SwaggerResponse(201, "The author was successfully created.", typeof(AuthorResource))]
		[SwaggerResponse(400, "The author data is not valid.")]
		public async Task<IActionResult> PostAsync([FromBody] SaveAuthorResource resource) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState.GetErrorMessages());
			
			var author = _mapper.Map<SaveAuthorResource, Author>(resource);

			var result = await _authorService.SaveAsync(author);

			if (!result.Success)
				return BadRequest(result.Message);

			var tutorialResource = _mapper.Map<Author, AuthorResource>(result.Resource);

			return Ok(tutorialResource);
		}
	}
}
