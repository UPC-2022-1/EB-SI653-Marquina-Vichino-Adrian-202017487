using System.ComponentModel.DataAnnotations;

using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu202017487.API.MagnetArt.Painting.Resources {
	public class SaveAuthorResource {
		[Required]
		[SwaggerSchema("Author First Name")]
		public string FirstName { get; set; }
		[SwaggerSchema("Author Last Name")]
		[Required]
		public string LastName { get; set; }
		[SwaggerSchema("Author Nickname")]
		[Required]
		public string Nickname { get; set; }
		[SwaggerSchema("Author Photo Url")]
		public string PhotoUrl { get; set; }
	}
}
