namespace Juice.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class B : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.ProductImages", "ProductID", "dbo.Products");
            DropForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "SubCategoryID", "dbo.SubCategories");
            DropIndex("dbo.Products", new[] { "SubCategoryID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.ProductImages", new[] { "ProductID" });
            DropIndex("dbo.SubCategories", new[] { "CategoryID" });
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
            DropTable("dbo.ProductImages");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ProductID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BrandName = c.String(),
                        BrandCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
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
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.SubCategories", "CategoryID");
            CreateIndex("dbo.ProductImages", "ProductID");
            CreateIndex("dbo.Products", "BrandID");
            CreateIndex("dbo.Products", "SubCategoryID");
            AddForeignKey("dbo.Products", "SubCategoryID", "dbo.SubCategories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductImages", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "BrandID", "dbo.Brands", "Id", cascadeDelete: true);
        }
    }
}
