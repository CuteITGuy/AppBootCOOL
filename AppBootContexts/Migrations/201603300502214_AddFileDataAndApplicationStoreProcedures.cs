using System.Data.Entity.Migrations;


namespace AppBootContexts.Migrations
{
    public partial class AddFileDataAndApplicationStoreProcedures: DbMigration
    {
        #region Override
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteFileData");
            DropStoredProcedure("dbo.UpdateFileData");
            DropStoredProcedure("dbo.InsertFileData");
            DropStoredProcedure("dbo.DeleteApplication");
            DropStoredProcedure("dbo.UpdateApplication");
            DropStoredProcedure("dbo.InsertApplication");
        }

        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.InsertApplication",
                p => new
                {
                    Description = p.String(maxLength: 1024, unicode: false),
                    Directory = p.String(maxLength: 512, unicode: false),
                    Name = p.String(maxLength: 128, unicode: false),
                },
                body:
                    @"INSERT [dbo].[Application]([Name], [Directory], [Description], [CreatedOn], [ModifiedOn])
                      VALUES (@Name, @Directory, @Description, GETDATE(), GETDATE())
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Application]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Application] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
                );

            CreateStoredProcedure(
                "dbo.UpdateApplication",
                p => new
                {
                    Id = p.Int(),
                    Description = p.String(maxLength: 1024, unicode: false),
                    Directory = p.String(maxLength: 512, unicode: false),
                    Name = p.String(maxLength: 128, unicode: false),
                },
                body:
                    @"UPDATE [dbo].[Application]
                      SET [Name] = @Name, [Directory] = @Directory, [Description] = @Description, [ModifiedOn] = GETDATE()
                      WHERE ([Id] = @Id)"
                );

            CreateStoredProcedure(
                "dbo.DeleteApplication",
                p => new
                {
                    Id = p.Int(),
                },
                body:
                    @"DELETE [dbo].[Application]
                      WHERE ([Id] = @Id)"
                );

            CreateStoredProcedure(
                "dbo.InsertFileData",
                p => new
                {
                    FileInfoId = p.Int(),
                    Data = p.Binary(),
                    Hash = p.Binary(maxLength: 16, fixedLength: true),
                    Size = p.Int(),
                },
                body:
                    @"INSERT [dbo].[FileData]([FileInfoId], [Data], [Hash], [Size])
                      VALUES (@FileInfoId, @Data, @Hash, @Size)"
                );

            CreateStoredProcedure(
                "dbo.UpdateFileData",
                p => new
                {
                    FileInfoId = p.Int(),
                    Data = p.Binary(),
                    Hash = p.Binary(maxLength: 16, fixedLength: true),
                    Size = p.Int(),
                },
                body:
                    @"UPDATE [dbo].[FileData]
                      SET [Data] = @Data, [Hash] = @Hash, [Size] = @Size
                      WHERE ([FileInfoId] = @FileInfoId)"
                );

            CreateStoredProcedure(
                "dbo.DeleteFileData",
                p => new
                {
                    FileInfoId = p.Int(),
                },
                body:
                    @"DELETE [dbo].[FileData]
                      WHERE ([FileInfoId] = @FileInfoId)"
                );
        }
        #endregion
    }
}