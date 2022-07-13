using System.ComponentModel.DataAnnotations;

using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu202017487.API.MagnetArt.Training.Resources {
	public class SaveProviderResource {
		[Required]
		[SwaggerSchema("Provider First Name")]
		public string Name { get; set; }
		[SwaggerSchema("Provider Last Name")]
		[Required]
		public string ApiUrl { get; set; }
		[SwaggerSchema("Provider Nickname")]
		[Required]
		public bool KeyRequired { get; set; }
		[SwaggerSchema("Provider Photo Url")]
		public string ApiKey { get; set; }
	}
}
