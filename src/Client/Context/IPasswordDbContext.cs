using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Client.Context;

/// <summary>
/// The password db context interface.
/// </summary>
public interface IPasswordDbContext
{
	/// <summary>
	/// Gets the database.
	/// </summary>
	DatabaseFacade Database { get; }

	/// <summary>
	/// Gets or sets the passwords.
	/// </summary>
	DbSet<Password> Passwords { get; set; }

    /// <summary>
	/// Save the changes asynchronously.
	/// </summary>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>A Task of type int</returns>
	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}