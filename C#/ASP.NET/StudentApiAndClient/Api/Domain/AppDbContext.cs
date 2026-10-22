using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using Microsoft.EntityFrameworkCore;

namespace ASPHW6.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    
        public AppDbContext(DbContextOptions opt) : base(opt) { }
    }
}
