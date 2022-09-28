using Cvecara.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cvecara.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Arrangement> Arrangements { get; set; }
        public DbSet<ArrangementItem> ArrangementItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ArrangementItem>().HasKey(k => new { k.ArrangementId, k.ItemId });
        }
    }
}
