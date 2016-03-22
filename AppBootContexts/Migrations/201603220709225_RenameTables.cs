namespace AppBootContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FileInfoes", newName: "FileInfo");
            RenameTable(name: "dbo.FileDatas", newName: "FileData");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FileData", newName: "FileDatas");
            RenameTable(name: "dbo.FileInfo", newName: "FileInfoes");
        }
    }
}
