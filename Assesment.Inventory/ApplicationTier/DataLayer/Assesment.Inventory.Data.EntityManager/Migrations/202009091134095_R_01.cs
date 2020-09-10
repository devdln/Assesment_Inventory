namespace Assesment.Inventory.Data.EntityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class R_01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "item.Items",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        UnitsAvaialble = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecordStatusId = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 150),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 150),
                        ModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("metadata.RecordStatus", t => t.RecordStatusId, cascadeDelete: true)
                .Index(t => t.RecordStatusId);
            
            CreateTable(
                "metadata.RecordStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("item.Items", "RecordStatusId", "metadata.RecordStatus");
            DropIndex("item.Items", new[] { "RecordStatusId" });
            DropTable("metadata.RecordStatus");
            DropTable("item.Items");
        }
    }
}
