using System.Globalization;

namespace si653ebu202017487.API.Security.Exceptions;


public class AppException : Exception {
	public AppException() : base() { }


	public AppException(string? message) : base(message) {
	}

	public AppException(string message, params object[] args)
		: base(String.Format(CultureInfo.CurrentCulture, message, args)) {
	}
}