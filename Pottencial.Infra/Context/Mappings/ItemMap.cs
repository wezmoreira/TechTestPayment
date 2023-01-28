using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pottencial.Domain.Entities;

namespace Pottencial.Infra.Context.Mappings;

public class ItemMap : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(280);

        builder.Property(x => x.Skuid)
            .IsRequired()
            .HasColumnName("Skuid")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("DECIMAL");

        builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnName("Amount")
            .HasColumnType("DECIMAL");
    }
}