namespace SimpleFormGenerator.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fields", "TitleEn", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fields", "TitleEn", c => c.String());
        }
    }
}
