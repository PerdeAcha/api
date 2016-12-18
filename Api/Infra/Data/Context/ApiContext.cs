using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Entities;
using Infra.Data.EntityConfig;

namespace Infra.Data.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ItemConfiguration(modelBuilder);
        }
    }
}
