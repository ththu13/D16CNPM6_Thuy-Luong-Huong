namespace Ashion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_DatabaseStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Usename", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Usename");
        }
    }
}
