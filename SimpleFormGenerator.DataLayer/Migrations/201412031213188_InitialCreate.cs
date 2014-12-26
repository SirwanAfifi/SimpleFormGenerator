namespace SimpleFormGenerator.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleEn = c.String(),
                        TitleFa = c.String(),
                        FieldType = c.Int(nullable: false),
                        FormId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.FormId, cascadeDelete: true)
                .Index(t => t.FormId);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Page = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Values",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Val = c.String(),
                        FieldId = c.Int(nullable: false),
                        FormId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .ForeignKey("dbo.Forms", t => t.FormId)
                .Index(t => t.FieldId)
                .Index(t => t.FormId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Values", "FormId", "dbo.Forms");
            DropForeignKey("dbo.Values", "FieldId", "dbo.Fields");
            DropForeignKey("dbo.Fields", "FormId", "dbo.Forms");
            DropIndex("dbo.Values", new[] { "FormId" });
            DropIndex("dbo.Values", new[] { "FieldId" });
            DropIndex("dbo.Fields", new[] { "FormId" });
            DropTable("dbo.Values");
            DropTable("dbo.Forms");
            DropTable("dbo.Fields");
        }
    }
}
