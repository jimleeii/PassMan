using System.Text.Json.Serialization;

namespace Client.Models;

/// <summary>
/// The parcel.
/// </summary>
[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
public sealed class Parcel
{
	/// <summary>
	/// Gets or sets the text.
	/// </summary>
	public required string Text { get; set; }

	/// <summary>
	/// Gets or sets the key.
	/// </summary>
	public required string Key { get; set; }
}