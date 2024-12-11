using System.ComponentModel;

namespace Client.Entities;

/// <summary>
/// The password.
/// </summary>
public class Password : IStampEntity
{
	/// <summary>
	/// Gets or sets the id.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the host.
	/// </summary>
	public required string Host { get; set; }

	/// <summary>
	/// Gets or sets the user.
	/// </summary>
	public required string User { get; set; }

	/// <summary>
	/// Gets or sets the pass code.
	/// </summary>
	[Browsable(false)]
	public required string Passcode { get; set; }

	/// <summary>
	/// Gets or sets the secret id.
	/// </summary>
	[Browsable(false)]
	public required Guid SecretId { get; set; }

	/// <summary>
	/// Gets or sets the secret.
	/// </summary>
	[Browsable(false)]
	public Secret? Secret { get; set; }

	/// <summary>
	/// Gets or sets the create by user id.
	/// </summary>
	[Browsable(false)]
	public string? CreateByUserId { get; set; }

	/// <summary>
	/// Gets or sets the create date.
	/// </summary>
	[Browsable(false)]
	public DateTime? CreateDate { get; set; }

	/// <summary>
	/// Gets or sets the update by user id.
	/// </summary>
	[Browsable(false)]
	public string? UpdateByUserId { get; set; }

	/// <summary>
	/// Gets or sets the update date.
	/// </summary>
	[Browsable(false)]
	public DateTime? UpdateDate { get; set; }
}