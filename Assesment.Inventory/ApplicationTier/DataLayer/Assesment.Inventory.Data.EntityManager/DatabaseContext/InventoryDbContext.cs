using Assesment.Inventory.Data.EntityManager.Migrations;
using Assesment.Inventory.Data.Model.Item;
using Assesment.Inventory.Data.Model.Metadata;
using System.Data.Entity;

namespace Assesment.Inventory.Data.EntityManager.DatabaseContext
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
            : base("ApplicationDatabase")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventoryDbContext, Configuration>());
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<RecordStatus> RecordStatus { get; set; }
    }
}
