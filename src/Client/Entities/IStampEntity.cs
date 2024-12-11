namespace Client.Entities;

/// <summary>
/// Stamp entity interface.
/// </summary>
public interface IStampEntity
{
	/// <summary>
	/// Gets or sets the create by user id.
	/// </summary>
	string? CreateByUserId { get; set; }

	/// <summary>
	/// Gets or sets the create date.
	/// </summary>
	DateTime? CreateDate { get; set; }

	/// <summary>
	/// Gets or sets the update by user id.
	/// </summary>
	string? UpdateByUserId { get; set; }

	/// <summary>
	/// Gets or sets the update date.
	/// </summary>
	DateTime? UpdateDate { get; set; }
}