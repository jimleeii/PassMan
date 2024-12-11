using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Client.Context;

/// <summary>
/// The password db context.
/// </summary>
public class PasswordDbContext(DbContextOptions<PasswordDbContext> options) : DbContext(options), IPasswordDbContext
{
	/// <summary>
	/// Gets or sets the passwords.
	/// </summary>
	public DbSet<Password> Passwords { get; set; }

	/// <summary>
	/// Gets or sets the secrets.
	/// </summary>
	public DbSet<Secret> Secrets { get; set; }

	/// <summary>
	/// On model creating.
	/// </summary>
	/// <param name="modelBuilder">The model builder.</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(PasswordDbContext).Assembly);
	}

	/// <summary>
	/// Save the changes asynchronously.
	/// </summary>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>A Task of type int</returns>
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
			if (entry.State == EntityState.Modified)
			{
				entry.Entity.UpdateByUserId = user;
				entry.Entity.UpdateDate = dateTime;
			}
		}

		return await base.SaveChangesAsync(cancellationToken);
	}
}