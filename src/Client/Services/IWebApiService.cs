namespace Client.Services;

/// <summary>
/// The web API service interface.
/// </summary>
public interface IWebApiService
{
	/// <summary>
	/// Get and return a task of type string asynchronously.
	/// </summary>
	/// <param name="uri">The URI.</param>
	/// <returns>A Task of type string</returns>
	Task<string> GetAsync(string uri);

	/// <summary>
	/// Post and return a task of type bool asynchronously.
	/// </summary>
	/// <typeparam name="T"/>
	/// <param name="uri">The URI.</param>
	/// <param name="item">The item.</param>
	/// <returns>A Task of type bool</returns>
	Task<(string? Response, bool Success)> PostAsync<T>(string uri, T item);

	/// <summary>
	/// Puts and return a task of type bool asynchronously.
	/// </summary>
	/// <typeparam name="T"/>
	/// <param name="uri">The URI.</param>
	/// <param name="item">The item.</param>
	/// <returns>A Task of type bool</returns>
	Task<bool> PutAsync<T>(string uri, T item);

	/// <summary>
	/// Deletes and return a task of type bool asynchronously.
	/// </summary>
	/// <param name="uri">The URI.</param>
	/// <returns>A Task of type bool</returns>
	Task<bool> DeleteAsync(string uri);
}