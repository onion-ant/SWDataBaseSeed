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
        DbSet<ItemCatalog> ItemsCatalog { get; set; }
        DbSet<Streaming> Streamings { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Addon> addons { get; set; }
        DbSet<ItemCatalog_Streaming> ItemsCatalog_Streamings { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
