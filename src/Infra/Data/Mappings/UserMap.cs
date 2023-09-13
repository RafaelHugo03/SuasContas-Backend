using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("name");

            builder.Property(u => u.EmailAddress)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("email_address");

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("password");

            builder.Property(u => u.ReceiveEmail)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("receive_email");

            builder.Property(u => u.IsValidEmail)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("is_valid_email");

            builder.Property(u => u.IsPremiumUser)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("is_premium_user");

            builder.Property(u => u.Role)
                .IsRequired()
                .HasColumnType("smallint")
                .HasColumnName("role");
        }
    }
}