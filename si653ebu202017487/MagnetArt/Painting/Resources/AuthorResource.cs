using Swashbuckle.AspNetCore.Annotations;

namespace si653ebu202017487.API.MagnetArt.Painting.Resources {
	public class AuthorResource {
		[SwaggerSchema("Author Identifier")]
		public int Id { get; set; }
		[SwaggerSchema("Author First Name")]
		public string FirstName { get; set; }
		[SwaggerSchema("Author Last Name")]
		public string LastName { get; set; }
		[SwaggerSchema("Author Nickname")]
		public string Nickname { get; set; }	
	}
}
