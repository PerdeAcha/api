using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Data.EntityConfig
{
    public class ItemConfiguration
    {
        public ItemConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity => {
                entity.Property(c => c.Title)
                    .IsRequired()
                    .HasMaxLength(150);
            });
        }
    }
}
