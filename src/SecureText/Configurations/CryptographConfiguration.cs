using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SecureText.Configurations;

/// <summary>
/// The password configuration.
/// </summary>
public class CryptographConfiguration : IEntityTypeConfiguration<Cryptograph>
{
	/// <summary>
	/// Configuration.
	/// </summary>
	/// <param name="builder">The builder.</param>
	public void Configure(EntityTypeBuilder<Cryptograph> builder)
	{
		builder.Property(p => p.CipherText).IsRequired();
		builder.Property(p => p.VectorBase64).IsRequired();
		builder.Property(p => p.CreateByUserId).IsRequired().HasMaxLength(45);
		builder.Property(p => p.CreateDate).IsRequired();

		builder.HasKey(p => p.VectorBase64);

		builder.ToTable("Cryptograph");
	}
}