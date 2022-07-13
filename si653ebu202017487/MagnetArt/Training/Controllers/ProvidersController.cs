using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using si653ebu202017487.API.MagnetArt.Painting.Resources;
using si653ebu202017487.API.MagnetArt.Training.Domain.Models;
using si653ebu202017487.API.MagnetArt.Training.Domain.Services;
using si653ebu202017487.API.MagnetArt.Training.Resources;
using si653ebu202017487.API.Shared.Extensionss;

using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu202017487.API.MagnetArt.Training.Controllers {
	[Produces("application/json")]
	[ApiController]
	[Route("/api/v1/[controller]")]
	public class ProvidersController : ControllerBase {
		private readonly IProviderService _providerService;
		private readonly IMapper _mapper;

		
		public ProvidersController(IProviderService authorService, IMapper mapper) {
			_providerService = authorService;
			_mapper = mapper;
		}



		/// <summary>
		/// Find a provider by id
		/// </summary>
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(AuthorResource), 200)]
		[ProducesResponseType(typeof(string), 404)]
		[ProducesResponseType(500)]
		[Produces("application/json", "text/plain")]
		[ProducesResponseType(typeof(IEnumerable<AuthorResource>), 200)]
		[SwaggerResponse(200, "The provider was successfully found.", typeof(ProviderResource))]
		[SwaggerResponse(404, "Provider not found.")]
		public async Task<IActionResult> GetByProviderIdAsync(int id) {
			var provider = await _providerService.ListByProviderIdAsync(id);
			var resource = _mapper.Map<Provider, ProviderResource>(provider);
			if (resource is null)
				return NotFound("Provider with id " + id.ToString() + " not found");

			return Ok(resource);

		}


		/// <summary>
		/// Create an provider
		/// </summary>
		[HttpPost]
		[ProducesResponseType(typeof(ProviderResource), 201)]
		[ProducesResponseType(typeof(List<string>), 400)]
		[ProducesResponseType(500)]
		[Consumes("application/json")]
		[Produces("application/json")]
		[SwaggerResponse(201, "The provider was successfully created.", typeof(ProviderResource))]
		[SwaggerResponse(400, "The provider data is not valid.")]
		public async Task<IActionResult> PostAsync([FromBody] SaveProviderResource resource) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState.GetErrorMessages());
			
			var provider = _mapper.Map<SaveProviderResource, Provider>(resource);

			var result = await _providerService.SaveAsync(provider);

			if (!result.Success)
				return BadRequest(result.Message);

			var providerResource = _mapper.Map<Provider, ProviderResource>(result.Resource);

			return Ok(providerResource);
		}
	}
}
