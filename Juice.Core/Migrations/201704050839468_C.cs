namespace Juice.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class C : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        FrontImage = c.String(),
                        ProductCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Description = c.String(),
                        SubCategoryID = c.Long(nullable: false),
                        BrandID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brand", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BrandName = c.String(),
                        BrandCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ProductID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        CategoryID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SubCategoryID", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.ProductImages", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "BrandID", "dbo.Brand");
            DropIndex("dbo.SubCategories", new[] { "CategoryID" });
            DropIndex("dbo.ProductImages", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "BrandID" });
            DropIndex("dbo.Product", new[] { "SubCategoryID" });
            DropTable("dbo.Categories");
            DropTable("dbo.SubCategories");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Brand");
            DropTable("dbo.Product");
        }
    }
}
