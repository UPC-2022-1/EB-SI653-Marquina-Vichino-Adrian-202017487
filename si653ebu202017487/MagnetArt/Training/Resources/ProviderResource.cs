using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu202017487.API.MagnetArt.Training.Resources {
	public class ProviderResource {
		[SwaggerSchema("Provider Identifier")]
		public int Id { get; set; }
		[SwaggerSchema("Provider Name")]
		public string Name { get; set; }
		[SwaggerSchema("Provider Api Url")]
		public string ApiUrl { get; set; }
		[SwaggerSchema("Provider Key Required")]
		public bool KeyRequired { get; set; }
		[SwaggerSchema("Provider Api Key")]
		public string ApiKey { get; set; }
	}
}
