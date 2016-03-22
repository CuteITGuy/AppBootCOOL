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
        }
        #endregion
    }
}