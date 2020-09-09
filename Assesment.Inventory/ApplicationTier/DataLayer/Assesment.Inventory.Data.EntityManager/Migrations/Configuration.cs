namespace Assesment.Inventory.Data.EntityManager.Migrations
{
    using Assesment.Inventory.Common.Model.Enums;
    using Assesment.Inventory.Data.Model.Metadata;
    using ItemSchema = Assesment.Inventory.Data.Model.Item;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assesment.Inventory.Data.EntityManager.DatabaseContext.InventoryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Assesment.Inventory.Data.EntityManager.DatabaseContext.InventoryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            try
            {                
                ItemSchema.Item item = context.Items.Where(a => a.Id == 1).FirstOrDefault<ItemSchema.Item>();
                if(item == null)
                {
                    context.RecordStatus.AddOrUpdate<RecordStatus>(new RecordStatus { Id = (int)RecordStatuses.Active, Description = "Active" });
                    context.RecordStatus.AddOrUpdate<RecordStatus>(new RecordStatus { Id = (int)RecordStatuses.Delete, Description = "Delete" });

                    context.Items.Add(new ItemSchema.Item { Id = 1, Name = "Red Rice", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 2, Name = "Cauliflower", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 3, Name = "Cabbage", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 4, Name = "Chicken", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 5, Name = "Beans", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 6, Name = "Oranges", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });

                    context.Items.Add(new ItemSchema.Item { Id = 7, Name = "Dhal", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 8, Name = "Grapes", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 9, Name = "Potatoes", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 10, Name = "Salad Leaves", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 11, Name = "White Rice", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });
                    context.Items.Add(new ItemSchema.Item { Id = 12, Name = "Flour", ReOrderLevel = 10.0M, UnitPrice = 100.00M, UnitsAvaialble = 1.5M, RecordStatusId = (int)RecordStatuses.Active });

                    context.SaveChanges();
                }                                
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
    }
}
