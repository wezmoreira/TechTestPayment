using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pottencial.Domain.Entities;

namespace Pottencial.Infra.Context.Mappings;

public class SellerMap : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("Sellers");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasColumnName("Cpf")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(180);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(180);

        builder.Property(x => x.Phone)
            .IsRequired()
            .HasColumnName("Phone")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(40);
    }
}