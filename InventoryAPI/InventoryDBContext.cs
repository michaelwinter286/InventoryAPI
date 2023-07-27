using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;
using System.Collections.Generic;

namespace InventoryAPI
{
    public class InventoryDBContext : DbContext
    {
        public DbSet<Supplies> Supplies { get; set; }
        public DbSet<Livestock> Livestock { get; set; }

        public string DbPath { get; }

        public InventoryDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "inventoryapidb.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
