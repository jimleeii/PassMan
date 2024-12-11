namespace Client.Entities;

/// <summary>
/// The secret.
/// </summary>
public class Secret : IStampEntity
{
	/// <summary>
	/// Gets or sets the id.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the key.
	/// </summary>
	public required string Key { get; set; }

	/// <summary>
	/// Gets or sets the passwords.
	/// </summary>
	public ICollection<Password> Passwords { get; set; }

	/// <summary>
	/// Gets or sets the create by user id.
	/// </summary>
	public string? CreateByUserId { get; set; }

	/// <summary>
	/// Gets or sets the create date.
	/// </summary>
	public DateTime? CreateDate { get; set; }

	/// <summary>
	/// Gets or sets the update by user id.
	/// </summary>
	public string? UpdateByUserId { get; set; }

	/// <summary>
	/// Gets or sets the update date.
	/// </summary>
	public DateTime? UpdateDate { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="Secret"/> class.
	/// </summary>
	public Secret()
	{
		Passwords = [];
	}
}