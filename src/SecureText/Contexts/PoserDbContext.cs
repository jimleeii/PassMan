using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SecureText.Contexts;

/// <summary>
/// The poser db context.
/// </summary>
/// <param name="options">The options.</param>
public class PoserDbContext(DbContextOptions<PoserDbContext> options) : DbContext(options), IPoserDbContext
{
	/// <summary>
	/// Gets or sets the cryptographs.
	/// </summary>
	public required DbSet<Cryptograph> Cryptographs { get; set; }

	/// <summary>
	/// On model creating.
	/// </summary>
	/// <param name="modelBuilder">The model builder.</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(PoserDbContext).Assembly);
	}

	/// <summary>
	/// Save the changes asynchronously.
	/// </summary>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>A <see cref="Task"/> of type <see cref="int"/>.</returns>
	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		string user = Environment.UserName;
		DateTime dateTime = DateTime.Now;

		foreach (EntityEntry<IStampEntity> entry in ChangeTracker.Entries<IStampEntity>())
		{
			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreateByUserId = user;
				entry.Entity.CreateDate = dateTime;
			}
		}

		return await base.SaveChangesAsync(cancellationToken);
	}
}