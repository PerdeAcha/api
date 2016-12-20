using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Entities;
using Api.Infra.Data.EntityConfig;

namespace Infra.Data.Context
{
    public class ApiContext : IdentityDbContext<User>
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ItemConfiguration(modelBuilder);
        }
    }
}
