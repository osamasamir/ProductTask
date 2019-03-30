namespace Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Price = c.Double(nullable: false),
                        ProductCategoriesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoriesId, cascadeDelete: true)
                .Index(t => t.ProductCategoriesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductCategoriesId", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "ProductCategoriesId" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
        }
    }
}
