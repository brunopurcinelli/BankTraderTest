using BankTrader.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankTrader.Infra.Data.Mappings
{
    public class TradeMap : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Value)
                .HasColumnType("double")
                .HasDefaultValue(0.0)
                .IsRequired();

            builder.Property(c => c.ClientSector)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .HasDefaultValue("")
                .IsRequired();
        }
    }
}
