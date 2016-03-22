namespace AppBootContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SplitFileTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.File", newName: "FileInfoes");
            CreateTable(
                "dbo.FileDatas",
                c => new
                    {
                        FileInfoId = c.Int(nullable: false),
                        Data = c.Binary(nullable: false),
                        Hash = c.Binary(nullable: false, maxLength: 16, fixedLength: true),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileInfoId)
                .ForeignKey("dbo.FileInfoes", t => t.FileInfoId, cascadeDelete: true)
                .Index(t => t.FileInfoId);
            
            DropColumn("dbo.FileInfoes", "Data");
            DropColumn("dbo.FileInfoes", "Hash");
            DropColumn("dbo.FileInfoes", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileInfoes", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.FileInfoes", "Hash", c => c.Binary(nullable: false, maxLength: 16, fixedLength: true));
            AddColumn("dbo.FileInfoes", "Data", c => c.Binary(nullable: false));
            DropForeignKey("dbo.FileDatas", "FileInfoId", "dbo.FileInfoes");
            DropIndex("dbo.FileDatas", new[] { "FileInfoId" });
            DropTable("dbo.FileDatas");
            RenameTable(name: "dbo.FileInfoes", newName: "File");
        }
    }
}
