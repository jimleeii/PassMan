using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configurations;

/// <summary>
/// The password configuration.
/// </summary>
public class PasswordConfiguration : IEntityTypeConfiguration<Password>
{
	/// <summary>
	/// Configuration.
	/// </summary>
	/// <param name="builder">The builder.</param>
	public void Configure(EntityTypeBuilder<Password> builder)
	{
		builder.Property(p => p.Id).IsRequired();
		builder.Property(p => p.Host).IsRequired();
		builder.Property(p => p.User).IsRequired(); builder.Property(p => p.CreateByUserId).IsRequired().HasMaxLength(45);
		builder.Property(p => p.CreateDate).IsRequired();
		builder.Property(p => p.UpdateByUserId).HasMaxLength(45);
		builder.Property(p => p.Passcode).IsRequired();
		builder.Property(p => p.SecretId).IsRequired();
		builder.Property(p => p.CreateByUserId).IsRequired().HasMaxLength(45);
		builder.Property(p => p.CreateDate).IsRequired();
		builder.Property(p => p.UpdateByUserId).HasMaxLength(45);

		builder.HasKey(p => p.Id);
		builder.HasOne(p => p.Secret).WithMany(s => s.Passwords).HasForeignKey(p => p.SecretId);

		builder.ToTable("Password");
	}
}