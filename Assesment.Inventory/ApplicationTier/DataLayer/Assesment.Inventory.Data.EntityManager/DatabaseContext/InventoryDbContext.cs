using Assesment.Inventory.Data.EntityManager.Migrations;
using Assesment.Inventory.Data.Model.Item;
using Assesment.Inventory.Data.Model.Metadata;
using System.Data.Entity;

namespace Assesment.Inventory.Data.EntityManager.DatabaseContext
{
    /// <summary>
    /// InventoryDbContext class
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class InventoryDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryDbContext"/> class.
        /// </summary>
        public InventoryDbContext()
            : base("ApplicationDatabase")
        {
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuilder, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventoryDbContext, Configuration>());
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Gets or sets the record status.
        /// </summary>
        /// <value>
        /// The record status.
        /// </value>
        public DbSet<RecordStatus> RecordStatus { get; set; }
    }
}
