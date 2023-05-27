namespace job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "CategoryId");
            AddForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            DropColumn("dbo.Jobs", "CategoryId");
        }
    }
}
