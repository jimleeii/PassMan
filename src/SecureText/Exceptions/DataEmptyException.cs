namespace SecureText.Exceptions;

/// <summary>
/// The data empty exception.
/// </summary>
/// <summary>
/// The exception that is thrown when the data is empty.
/// </summary>
public class DataEmptyException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="DataEmptyException"/> class.
	/// </summary>
	public DataEmptyException() : base("Data is empty")
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DataEmptyException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	public DataEmptyException(string message) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DataEmptyException"/> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="innerException">The inner exception.</param>
	public DataEmptyException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
