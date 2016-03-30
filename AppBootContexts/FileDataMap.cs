using System.Data.Entity.ModelConfiguration;
using AppBootModels;


namespace AppBootContexts
{
    public class FileDataMap: EntityTypeConfiguration<FileData>
    {
        #region  Constructors & Destructor
        public FileDataMap()
        {
            ToTable("FileData");

            Property(p => p.FileInfoId).HasColumnOrder(50);
            Property(p => p.Data).HasColumnOrder(70).IsRequired();
            Property(p => p.Hash).HasColumnOrder(90).HasMaxLength(16).IsFixedLength().IsRequired();
            Property(p => p.Size).HasColumnOrder(110);

            HasRequired(fd => fd.FileInfo).WithOptional(fi => fi.FileData).WillCascadeOnDelete();
            HasKey(fd => fd.FileInfoId);

            MapToStoredProcedures(s =>
            {
                s.Insert(i => i.HasName("InsertFileData")
                               .Parameter(f => f.Data, "Data")
                               .Parameter(f => f.Hash, "Hash")
                               .Parameter(f => f.Size, "Size"));
                s.Update(u => u.HasName("UpdateFileData")
                               .Parameter(f => f.FileInfoId, "FileInfoId")
                               .Parameter(f => f.Data, "Data")
                               .Parameter(f => f.Hash, "Hash")
                               .Parameter(f => f.Size, "Size"));
                s.Delete(d => d.HasName("DeleteFileData")
                               .Parameter(f => f.FileInfoId, "FileInfoId"));
            });
        }
        #endregion
    }
}