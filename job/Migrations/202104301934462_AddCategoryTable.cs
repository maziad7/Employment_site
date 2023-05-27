namespace job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "Category_Id" });
            DropColumn("dbo.Jobs", "CategoreId");
            DropColumn("dbo.Jobs", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Category_Id", c => c.Int());
            AddColumn("dbo.Jobs", "CategoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "Category_Id");
            AddForeignKey("dbo.Jobs", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
