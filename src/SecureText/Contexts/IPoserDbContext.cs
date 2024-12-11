using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SecureText.Contexts;

/// <summary>
/// The poser db context interface.
/// </summary>
public interface IPoserDbContext
{
	/// <summary>
	/// Gets the database.
	/// </summary>
	DatabaseFacade Database { get; }

	/// <summary>
	/// Gets or sets the cryptographs.
	/// </summary>
	DbSet<Cryptograph> Cryptographs { get; set; }

	/// <summary>
	/// Save the changes asynchronously.
	/// </summary>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>A Task of type int</returns>
	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}