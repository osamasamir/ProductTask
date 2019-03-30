namespace Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inte : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 10),
                        UserPassword = c.String(nullable: false),
                        UserEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "User_Id", c => c.Int());
            CreateIndex("dbo.Products", "User_Id");
            AddForeignKey("dbo.Products", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "User_Id", "dbo.Users");
            DropIndex("dbo.Products", new[] { "User_Id" });
            DropColumn("dbo.Products", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
