using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Data.EntityConfig
{
    public class UserConfiguration
    {
        public UserConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.State)
                    .IsRequired()
                    .HasMaxLength(2);
            });
        }
    }
}
