using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace si653ebu202017487.API.Shared.Extensionss;

public static class ModelStateExtensions {
	public static List<string> GetErrorMessages(this ModelStateDictionary dictionary) {
		return dictionary.SelectMany(m => m.Value.Errors)
			.Select(m => m.ErrorMessage)
			.ToList();
	}

}