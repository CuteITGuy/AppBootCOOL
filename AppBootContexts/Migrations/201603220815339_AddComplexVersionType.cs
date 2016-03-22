namespace AppBootContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComplexVersionType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileInfo", "MajorVersion", c => c.Int());
            AddColumn("dbo.FileInfo", "MinorVersion", c => c.Int());
            AddColumn("dbo.FileInfo", "BuildVersion", c => c.Int());
            AddColumn("dbo.FileInfo", "RevisionVersion", c => c.Int());
            DropColumn("dbo.FileInfo", "Version");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileInfo", "Version", c => c.String(maxLength: 16, unicode: false));
            DropColumn("dbo.FileInfo", "RevisionVersion");
            DropColumn("dbo.FileInfo", "BuildVersion");
            DropColumn("dbo.FileInfo", "MinorVersion");
            DropColumn("dbo.FileInfo", "MajorVersion");
        }
    }
}
