namespace DoroboShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class full : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFilterNameGroups",
                c => new
                    {
                        FilterNameId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilterNameId, t.FilterValueId, t.CategoryId })
                .ForeignKey("dbo.tblCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.tblFilterNames", t => t.FilterNameId, cascadeDelete: true)
                .ForeignKey("dbo.tblFilterValues", t => t.FilterValueId, cascadeDelete: true)
                .Index(t => t.FilterNameId)
                .Index(t => t.FilterValueId)
                .Index(t => t.CategoryId);
            
            DropTable("dbo.FilterNameGroupsViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilterNameGroupsViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilterNameId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.tblFilterNameGroups", "FilterValueId", "dbo.tblFilterValues");
            DropForeignKey("dbo.tblFilterNameGroups", "FilterNameId", "dbo.tblFilterNames");
            DropForeignKey("dbo.tblFilterNameGroups", "CategoryId", "dbo.tblCategories");
            DropIndex("dbo.tblFilterNameGroups", new[] { "CategoryId" });
            DropIndex("dbo.tblFilterNameGroups", new[] { "FilterValueId" });
            DropIndex("dbo.tblFilterNameGroups", new[] { "FilterNameId" });
            DropTable("dbo.tblFilterNameGroups");
        }
    }
}
