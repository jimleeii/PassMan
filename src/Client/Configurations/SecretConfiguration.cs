using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configurations;

/// <summary>
/// The secret configuration.
/// </summary>
public class SecretConfiguration : IEntityTypeConfiguration<Secret>
{
	/// <summary>
	/// Configuration.
	/// </summary>
	/// <param name="builder">The builder.</param>
	public void Configure(EntityTypeBuilder<Secret> builder)
	{
		builder.Property(s => s.Id).IsRequired();
		builder.Property(s => s.Key).IsRequired();
		builder.Property(p => p.CreateByUserId).IsRequired().HasMaxLength(45);
		builder.Property(p => p.CreateDate).IsRequired();
		builder.Property(p => p.UpdateByUserId).HasMaxLength(45);

		builder.HasKey(s => s.Id);

		builder.ToTable("Secret");
	}
}