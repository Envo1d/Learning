using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_HW5.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_HW5.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AppDbContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tag>()
                .HasIndex(u => u.Title)
                .IsUnique();
        }
    }
}
