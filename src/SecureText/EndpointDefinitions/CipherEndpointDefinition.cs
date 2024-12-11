namespace SecureText.EndpointDefinitions;

/// <summary>
/// The cipher endpoint definition.
/// </summary>
public class CipherEndpointDefinition : IEndpointDefinition
{
	/// <summary>
	/// Defines the endpoints.
	/// </summary>
	/// <param name="app">The app.</param>
	public void DefineEndpoints(WebApplication app)
	{
		app.MapGet("api/GetKey", GenerateKeyAsync);
		app.MapPost("api/EncryptText", EncryptTextAsync);
		app.MapPost("api/DecryptText", DecryptTextAsync);
	}

	/// <summary>
	/// Defines the services.
	/// </summary>
	/// <param name="services">The services.</param>
	public void DefineServices(IServiceCollection services) => services.AddScoped<ICipherService, CipherService>();

	/// <summary>
	/// Generate the key asynchronously.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <returns>A Task of type IResult</returns>
	private static async Task<IResult> GenerateKeyAsync(ICipherService service)
	{
		var key = await service.GenerateKeyAsync();
		return Results.Ok(key);
	}

	/// <summary>
	/// Encrypts text asynchronously.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="parcel">The parcel.</param>
	/// <returns>A Task of type IResult</returns>
	private static async Task<IResult> EncryptTextAsync(ICipherService service, Parcel parcel)
	{
		var pass = await service.EncryptTextAsync(parcel.Text, parcel.Key);
		return Results.Ok(pass);
	}

	/// <summary>
	/// Decrypts the text asynchronously.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="parcel">The parcel.</param>
	/// <returns>A Task of type IResult</returns>
	private static async Task<IResult> DecryptTextAsync(ICipherService service, Parcel parcel)
	{
		var pass = await service.DecryptTextAsync(parcel.Text, parcel.Key);
		return Results.Ok(pass);
	}
}