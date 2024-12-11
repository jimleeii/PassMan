using Microsoft.OpenApi.Models;
using System.Reflection;

namespace SecureText.EndpointDefinitions;

/// <summary>
/// The swagger endpoint definition.
/// </summary>
public class SwaggerEndpointDefinition : IEndpointDefinition
{
	/// <summary>
	/// The version.
	/// </summary>
	private const string Version = "v1";

	private readonly string Title = Assembly.GetEntryAssembly()!.GetName().Name!;

	/// <summary>
	/// Defines the endpoints.
	/// </summary>
	/// <param name="app">The app.</param>
	public void DefineEndpoints(WebApplication app)
	{
		app.UseSwagger();
		app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Title} {Version}"));
	}

	/// <summary>
	/// Defines the services.
	/// </summary>
	/// <param name="services">The services.</param>
	public void DefineServices(IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen(c => c.SwaggerDoc(Version, new OpenApiInfo { Title = Title, Version = Version }));
	}
}