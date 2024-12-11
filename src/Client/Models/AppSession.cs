using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Client.Models;

/// <summary>
/// The App session.
/// </summary>
public static class AppSession
{
	// Event that is raised when the session is initialized.
	public static event EventHandler? Initialized;

	// The key
	public static string? Key { get; private set; }

	/// <summary>
	/// Gets or sets the context.
	/// </summary>
	public static PasswordDbContext? Context { get; private set; }

	/// <summary>
	/// Initializes the context and raises the <see cref="Initialized"/> event.
	/// </summary>
	public static async Task Initialize()
	{
		await InitializeKeyAsync();
		await InitializeContextAsync();
		Initialized?.Invoke(null, EventArgs.Empty);
	}

	/// <summary>
	/// Initializes the key asynchronously.
	/// </summary>
	/// <remarks>
	/// Gets the ApiUrl from the app.config file and the key from the web API.
	/// </remarks>
	private static async Task InitializeKeyAsync()
	{
		// Get the ApiUrl from the app.config file
		string? apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

		if (string.IsNullOrEmpty(apiUrl))
		{
			throw new MissingConfigurationException("ApiUrl is not set in the app.config file.");
		}

		// Get the key from the web API
		var webApiService = new WebApiService();
		var response = await webApiService.GetAsync($"{apiUrl}/api/GetKey");
		Key = response;
	}

	/// <summary>
	/// Initializes the context.
	/// </summary>
	private static async Task InitializeContextAsync()
	{
		// Get the connection string
		string connectionString = ConfigurationManager.ConnectionStrings["PasswordDbContext"].ConnectionString;

		// Create a DbContextOptions instance
		DbContextOptions<PasswordDbContext> options = new DbContextOptionsBuilder<PasswordDbContext>()
			.UseSqlite(connectionString)
			.Options;
		// Create the database using the connection string
		var context = new PasswordDbContext(options);
		await context.Database.EnsureCreatedAsync();

		Context = context;
	}
}