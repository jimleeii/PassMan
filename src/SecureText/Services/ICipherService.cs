namespace SecureText.Services;

/// <summary>
/// The cipher service interface.
/// </summary>
public interface ICipherService
{
	/// <summary>
	/// Generate the secret key asynchronously.
	/// </summary>
	/// <returns>A ValueTask of type string</returns>
	ValueTask<string> GenerateKeyAsync();

	/// <summary>
	/// Encrypts the text asynchronously.
	/// </summary>
	/// <param name="text">The text.</param>
	/// <param name="keyBase64">The key base64.</param>
	/// <returns>A ValueTask of type string</returns>
	ValueTask<string> EncryptTextAsync(string text, string keyBase64);

	/// <summary>
	/// Decrypts the text asynchronously.
	/// </summary>
	/// <param name="cipherText">The cipher text.</param>
	/// <param name="keyBase64">The key base64.</param>
	/// <returns>A ValueTask of type string</returns>
	ValueTask<string> DecryptTextAsync(string cipherText, string keyBase64);
}