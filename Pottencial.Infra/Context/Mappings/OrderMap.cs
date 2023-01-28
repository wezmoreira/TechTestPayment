using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Enums;

namespace Pottencial.Infra.Context.Mappings;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);

        builder.Property(x => x.Date)
            .IsRequired()
            .HasColumnName("DateSale")
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETDATE()");
        
        builder.Property(x => x.Total)
            .IsRequired()
            .HasColumnName("Total")
            .HasColumnType("DECIMAL");

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (EStatusOrder)Enum.Parse(typeof(EStatusOrder), v))
            .HasColumnName("Status")
            .HasColumnType("NVARCHAR") //verificar se nao vai dar conflito
            .HasMaxLength(120);

        builder
            .HasOne(x => x.Seller)
            .WithMany(x => x.Orders)
            .HasConstraintName("CT_Seller_Order")
            .OnDelete(DeleteBehavior.Cascade);
 
        builder
            .HasMany(x => x.Items)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "OrderItems",
                item => item
                    .HasOne<Item>()
                    .WithMany()
                    .HasForeignKey("ItemId")
                    .HasConstraintName("FK_Order_Item")
                    .OnDelete(DeleteBehavior.Cascade),
                order => order
                    .HasOne<Order>()
                    .WithMany()
                    .HasForeignKey("OrderId")
                    .HasConstraintName("FK_Item_Order")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}