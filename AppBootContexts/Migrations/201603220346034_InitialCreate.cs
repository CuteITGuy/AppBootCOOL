namespace AppBootContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128, unicode: false),
                        Directory = c.String(nullable: false, maxLength: 512, unicode: false),
                        Description = c.String(maxLength: 1024, unicode: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128, unicode: false),
                        Directory = c.String(nullable: false, maxLength: 512, unicode: false),
                        Extension = c.String(nullable: false, maxLength: 8, unicode: false),
                        Version = c.String(maxLength: 16, unicode: false),
                        Data = c.Binary(nullable: false),
                        Hash = c.Binary(nullable: false, maxLength: 16, fixedLength: true),
                        Size = c.Int(nullable: false),
                        Description = c.String(maxLength: 1024, unicode: false),
                        IsInit = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        ApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Application", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "ApplicationId", "dbo.Application");
            DropIndex("dbo.File", new[] { "ApplicationId" });
            DropTable("dbo.File");
            DropTable("dbo.Application");
        }
    }
}
