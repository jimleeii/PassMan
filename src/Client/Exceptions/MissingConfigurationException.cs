namespace Client.Exceptions;

/// <summary>
/// The missing configuration exception.
/// </summary>
public class MissingConfigurationException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MissingConfigurationException"/> class.
	/// </summary>
	/// <remarks>
	/// This exception is thrown when a configuration is missing.
	/// </remarks>
	public MissingConfigurationException() : base("Missing configuration")
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="MissingConfigurationException"/> class with a message.
	/// </summary>
	/// <param name="message">The message that describes the error.</param>
	public MissingConfigurationException(string? message) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="MissingConfigurationException"/> class with a message and an inner exception.
	/// </summary>
	/// <param name="message">The message that describes the error.</param>
	/// <param name="innerException">The inner exception that is the cause of this exception, or a null reference (<see langword="null"/>) if no inner exception is specified.</param>
	public MissingConfigurationException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}