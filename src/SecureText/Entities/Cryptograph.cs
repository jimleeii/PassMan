namespace SecureText.Entities;

/// <summary>
/// The password.
/// </summary>
public class Cryptograph : IStampEntity
{
	/// <summary>
	/// Gets or sets the cipher text.
	/// </summary>
	public required string CipherText { get; set; }

	/// <summary>
	/// Gets or sets the vector base64.
	/// </summary>
	public required string VectorBase64 { get; set; }

	/// <summary>
	/// Gets or sets the create by user id.
	/// </summary>
	public string? CreateByUserId { get; set; }

	/// <summary>
	/// Gets or sets the create date.
	/// </summary>
	public DateTime? CreateDate { get; set; }
}