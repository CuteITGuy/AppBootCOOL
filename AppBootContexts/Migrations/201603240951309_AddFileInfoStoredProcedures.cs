using System.Data.Entity.Migrations;


namespace AppBootContexts.Migrations
{
    public partial class AddFileInfoStoredProcedures: DbMigration
    {
        #region Override
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteFileInfo");
            DropStoredProcedure("dbo.UpdateFileInfo");
            DropStoredProcedure("dbo.InsertFileInfo");
        }

        public override void Up()
        {
            CreateStoredProcedure("dbo.InsertFileInfo",
                p => new
                {
                    ApplicationId = p.Int(),
                    Description = p.String(maxLength: 1024, unicode: false),
                    Directory = p.String(maxLength: 512, unicode: false),
                    Extension = p.String(maxLength: 8, unicode: false),
                    IsInit = p.Boolean(),
                    Name = p.String(maxLength: 128, unicode: false),
                    BuildVersion = p.Int(),
                    MajorVersion = p.Int(),
                    MinorVersion = p.Int(),
                    RevisionVersion = p.Int()
                },
                body:
                    @"INSERT [dbo].[FileInfo]([Name], [Directory], [Extension], [MajorVersion], [MinorVersion], [BuildVersion], [RevisionVersion], [Description], [IsInit], [CreatedOn], [ModifiedOn], [ApplicationId])
                      VALUES (@Name, @Directory, @Extension, @MajorVersion, @MinorVersion, @BuildVersion, @RevisionVersion, @Description, @IsInit, GETDATE(), GETDATE(), @ApplicationId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[FileInfo]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[FileInfo] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
                );

            CreateStoredProcedure(
                "dbo.UpdateFileInfo",
                p => new
                {
                    Id = p.Int(),
                    ApplicationId = p.Int(),
                    Description = p.String(maxLength: 1024, unicode: false),
                    Directory = p.String(maxLength: 512, unicode: false),
                    Extension = p.String(maxLength: 8, unicode: false),
                    IsInit = p.Boolean(),
                    Name = p.String(maxLength: 128, unicode: false),
                    BuildVersion = p.Int(),
                    MajorVersion = p.Int(),
                    MinorVersion = p.Int(),
                    RevisionVersion = p.Int(),
                },
                body:
                    @"UPDATE [dbo].[FileInfo]
                      SET [Name] = @Name, [Directory] = @Directory, [Extension] = @Extension, [MajorVersion] = @MajorVersion, [MinorVersion] = @MinorVersion, [BuildVersion] = @BuildVersion, [RevisionVersion] = @RevisionVersion, [Description] = @Description, [IsInit] = @IsInit, [ModifiedOn] = GETDATE(), [ApplicationId] = @ApplicationId
                      WHERE ([Id] = @Id)"
                );

            CreateStoredProcedure(
                "dbo.DeleteFileInfo",
                p => new
                {
                    Id = p.Int(),
                },
                body:
                    @"DELETE [dbo].[FileInfo]
                      WHERE ([Id] = @Id)"
                );
        }
        #endregion
    }
}