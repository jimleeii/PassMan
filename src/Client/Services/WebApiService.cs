using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Client.Services;

/// <summary>
/// The web API service.
/// </summary>
public class WebApiService : IWebApiService
{
	/// <summary>
	/// Deletes and return a task of type bool asynchronously.
	/// </summary>
	/// <param name="uri">The URI.</param>
	/// <exception cref="NotImplementedException"></exception>
	/// <returns>A Task of type bool</returns>
	public Task<bool> DeleteAsync(string uri)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Get and return a task of type string asynchronously.
	/// </summary>
	/// <param name="uri">The URI.</param>
	/// <returns>A Task of type string</returns>
	public async Task<string> GetAsync(string uri)
	{
		using var httpClient = new HttpClient();

		var response = await httpClient.GetStringAsync(uri);

		return response.Trim('"');
	}

	/// <summary>
	/// Post and return a task of type bool asynchronously.
	/// </summary>
	/// <typeparam name="T"/>
	/// <param name="uri">The URI.</param>
	/// <param name="item">The item.</param>
	/// <returns>A Task of type bool</returns>
	public async Task<(string? Response, bool Success)> PostAsync<T>(string uri, T item)
	{
		using var httpClient = new HttpClient();

		var content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
		var response = await httpClient.PostAsync(uri, content);

		var responseBody = await response.Content.ReadAsStringAsync();

		if (string.IsNullOrWhiteSpace(responseBody))
		{
			return (null, response.IsSuccessStatusCode);
		}

		try
		{
			var result = JsonSerializer.Deserialize<string>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			return (result, response.IsSuccessStatusCode);
		}
		catch (JsonException ex)
		{
			// Handle the JSON exception
			return (ex.Message, false);
		}
	}

	/// <summary>
	/// Puts and return a task of type bool asynchronously.
	/// </summary>
	/// <typeparam name="T"/>
	/// <param name="uri">The URI.</param>
	/// <param name="item">The item.</param>
	/// <exception cref="NotImplementedException"></exception>
	/// <returns>A Task of type bool</returns>
	public Task<bool> PutAsync<T>(string uri, T item)
	{
		throw new NotImplementedException();
	}
}