using Microsoft.EntityFrameworkCore;
using StartDatabaseSeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDatabaseSeed.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ItemCatalog> ItemsCatalog { get; set; }
        public DbSet<Streaming> Streamings { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Addon> addons { get; set; }
        public DbSet<ItemCatalog_Streaming> ItemsCatalog_Streamings { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
