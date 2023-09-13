using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class BillMap : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("bill");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("name");

            builder.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("float")
                .HasColumnName("price");

            builder.Property(b => b.Type)
                .IsRequired()
                .HasColumnType("smallint")
                .HasColumnName("type");
            
            builder.Property(b => b.DueDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("due_date");

            builder.Property(b => b.Installments)
                .IsRequired(false)
                .HasColumnType("smallint")
                .HasColumnName("installments");

            builder.Property(b => b.LastInstallmentDate)
                .IsRequired(false)
                .HasColumnType("datetime")
                .HasColumnName("last_installment_date");

            builder.Property(b => b.UserId)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasColumnName("user_id");

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bills)
                .HasForeignKey(b => b.UserId);
        }
    }
}