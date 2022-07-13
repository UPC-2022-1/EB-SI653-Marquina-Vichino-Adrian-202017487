namespace si653ebu202017487.API.MagnetArt.Training.Domain.Models {
	public class Provider {
		public int Id { get; set; }
		public string name { get; set; }
		public string apiUrl { get; set; }
		public bool keyRequired { get; set; } = false;
		public string apiKey { get; set; }
	}
}
