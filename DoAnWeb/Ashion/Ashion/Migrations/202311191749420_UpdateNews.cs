namespace Ashion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_News", "Category_Id", "dbo.tb_Category");
            DropIndex("dbo.tb_News", new[] { "Category_Id" });
            DropColumn("dbo.tb_News", "CategoryId");
            RenameColumn(table: "dbo.tb_News", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.tb_News", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_News", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_News", "CategoryId");
            AddForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_News", new[] { "CategoryId" });
            AlterColumn("dbo.tb_News", "CategoryId", c => c.Int());
            AlterColumn("dbo.tb_News", "CategoryId", c => c.String());
            RenameColumn(table: "dbo.tb_News", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.tb_News", "CategoryId", c => c.String());
            CreateIndex("dbo.tb_News", "Category_Id");
            AddForeignKey("dbo.tb_News", "Category_Id", "dbo.tb_Category", "Id");
        }
    }
}
