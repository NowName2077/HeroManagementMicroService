using HeroManagement.Domain.Aggregates.Entities;
using HeroManagement.Domain.ValueObjects;
using HeroManagement.Domain.ValueObjects.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroManagement.Infrastructure.EntityFramework.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.ItemName)
            .IsRequired()
            .HasConversion(itemName => itemName.Value, str => new ObjectName(str))
            .HasMaxLength(ObjectNameValidator.MAX_LENGTH);
    }
}