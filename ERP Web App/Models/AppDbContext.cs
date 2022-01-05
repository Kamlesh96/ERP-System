using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Web_App.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Brand> BrandMaster { get; set; }
        public DbSet<Model> ModelMaster { get; set; }
        public DbSet<Source> SourceMaster { get; set; }
    }
}
