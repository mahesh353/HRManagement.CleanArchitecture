using Microsoft.AspNetCore.Builder;

namespace HRManagement.API.Middleware
{
	public static class MiddlewareExtensions
	{
		public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ExceptionHandlerMiddleware>();
		}
	}
}
