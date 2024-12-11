using System.Security.Cryptography;

namespace SecureText.Services;

/// <summary>
/// The cipher service.
/// </summary>
/// <param name="dbContext">The db context.</param>
public class CipherService(IPoserDbContext dbContext) : ICipherService, IDisposable
{
	/// <summary>
	/// The flag to indicate if the resource has already been disposed.
	/// </summary>
	private bool _disposed = false;

	/// <summary>
	/// The AES algorithm.
	/// </summary>
	private Aes? _aesAlgorithm = Aes.Create();

	/// <summary>
	/// The database context.
	/// </summary>
	private readonly IPoserDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

	/// <summary>
	/// Public implementation of Dispose pattern callable by consumers.
	/// </summary>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	/// Protected implementation of Dispose pattern.
	/// </summary>
	/// <param name="disposing">The disposing flag.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (_disposed)
			return;

		if (disposing)
		{
			// Dispose managed resources
			if (_aesAlgorithm != null)
			{
				_aesAlgorithm.Dispose();
				_aesAlgorithm = null;
			}
		}

		// Free unmanaged resources (if any) here

		_disposed = true;
	}

	/// <summary>
	/// Destructor to ensure resources are released if Dispose is not called.
	/// </summary>
	~CipherService() => Dispose(false);

	/// <summary>
	/// Decrypts the text asynchronously.
	/// </summary>
	/// <param name="cipherText">The cipher text.</param>
	/// <param name="keyBase64">The key base64.</param>
	/// <exception cref="ArgumentNullException">Throw when the <paramref name="_aesAlgorithm"/> parameter is <b>null</b>.</exception>
	/// <exception cref="ArgumentNullException">Throw when the <paramref name="cipherText"/> parameter is <b>null</b>.</exception>
	/// <exception cref="ArgumentNullException">Throw when the <paramref name="keyBase64"/> parameter is <b>null</b>.</exception>
	/// <exception cref="DataEmptyException">Throw when the cryptograph data is empty.</exception>
	/// <returns>A ValueTask of type string</returns>
	public async ValueTask<string> DecryptTextAsync(string cipherText, string keyBase64)
	{
		ArgumentNullException.ThrowIfNull(_aesAlgorithm);
		ArgumentNullException.ThrowIfNull(cipherText);
		ArgumentNullException.ThrowIfNull(keyBase64);

		using (_aesAlgorithm)
		{
			_aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
			Cryptograph? cryptograph = _dbContext.Cryptographs.AsEnumerable().FirstOrDefault(graph => graph.CipherText.EqualsIgnoreCase(cipherText))
				?? throw new DataEmptyException();
			_aesAlgorithm.IV = Convert.FromBase64String(cryptograph.VectorBase64);

			// Create decryptor object
			ICryptoTransform decryptor = _aesAlgorithm.CreateDecryptor();

			byte[] cipher = Convert.FromBase64String(cipherText);

			//Decryption will be done in a memory stream through a CryptoStream object
			await using MemoryStream ms = new(cipher);
			await using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
			using StreamReader sr = new(cs);
			return await sr.ReadToEndAsync();
		}
	}

	/// <summary>
	/// Encrypts the text asynchronously.
	/// </summary>
	/// <param name="text">The text.</param>
	/// <param name="keyBase64">The key base64.</param>
	/// <exception cref="ArgumentNullException">Throw when the <paramref name="_aesAlgorithm"/> parameter is <b>null</b>.</exception>
	/// <exception cref="ArgumentNullException">Throw when the <paramref name="text"/> parameter is <b>null</b>.</exception>
	/// <exception cref="ArgumentNullException">Throw when the <paramref name="keyBase64"/> parameter is <b>null</b>.</exception>
	/// <exception cref="DataEmptyException">Throw when the encrypted data is empty.</exception>
	/// <returns>A ValueTask of type string</returns>
	public async ValueTask<string> EncryptTextAsync(string text, string keyBase64)
	{
		ArgumentNullException.ThrowIfNull(_aesAlgorithm);
		ArgumentNullException.ThrowIfNull(text);
		ArgumentNullException.ThrowIfNull(keyBase64);

		using (_aesAlgorithm)
		{
			_aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
			_aesAlgorithm.GenerateIV();

			// Set the parameters with out keyword
			string vectorBase64 = Convert.ToBase64String(_aesAlgorithm.IV);

			// Create encryptor object
			ICryptoTransform encryptor = _aesAlgorithm.CreateEncryptor();

			byte[] encryptedData;

			// Encryption will be done in a memory stream through a CryptoStream object
			await using MemoryStream ms = new();
			await using CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write);
			await using (StreamWriter sw = new(cs))
			{
				// Write data to the CryptoStream
				await sw.WriteAsync(text);
			}

			// Read the encrypted data from the MemoryStream
			encryptedData = ms.ToArray();

			// Check if the encryptedData array is empty
			if (encryptedData.Length == 0)
			{
				throw new DataEmptyException("Encrypted data is empty");
			}

			// Return the encrypted data
			string cipherText = Convert.ToBase64String(encryptedData);
			_dbContext.Cryptographs.Add(new Cryptograph { CipherText = cipherText, VectorBase64 = vectorBase64 });
			int _ = await _dbContext.SaveChangesAsync();

			if (_ > 0)
			{
				return cipherText;
			}

			throw new DataEmptyException("Encrypted data is empty");
		}
	}

	/// <summary>
	/// Generate the secret key asynchronously.
	/// </summary>
	/// <exception cref="ArgumentNullException">Throw when the <paramref name="_aesAlgorithm"/> parameter is <b>null</b>.</exception>
	/// <returns>A ValueTask of type string</returns>
	public async ValueTask<string> GenerateKeyAsync()
	{
		ArgumentNullException.ThrowIfNull(_aesAlgorithm);

		using (_aesAlgorithm)
		{
			_aesAlgorithm.KeySize = 256;
			_aesAlgorithm.GenerateKey();
			return await ValueTask.FromResult(Convert.ToBase64String(_aesAlgorithm.Key));
		}
	}
}