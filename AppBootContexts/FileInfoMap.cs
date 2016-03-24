﻿using System.Data.Entity.ModelConfiguration;
using AppBootModels;


namespace AppBootContexts
{
    public class FileInfoMap: EntityTypeConfiguration<FileInfo>
    {
        #region  Constructors & Destructor
        public FileInfoMap()
        {
            ToTable("FileInfo");

            Property(p => p.Id).HasColumnOrder(50);
            Property(p => p.Name).HasColumnOrder(70).HasMaxLength(128).IsUnicode(false).IsRequired();
            Property(p => p.Directory).HasColumnOrder(90).HasMaxLength(512).IsUnicode(false).IsRequired();
            Property(p => p.Extension).HasColumnOrder(110).HasMaxLength(8).IsUnicode(false).IsRequired();

            //Property(p => p.Version).HasColumnOrder(130).HasMaxLength(16).IsUnicode(false);
            Property(p => p.Version.Major).HasColumnOrder(130);
            Property(p => p.Version.Minor).HasColumnOrder(150);
            Property(p => p.Version.Build).HasColumnOrder(170);
            Property(p => p.Version.Revision).HasColumnOrder(190);
            Property(p => p.Description).HasColumnOrder(210).HasMaxLength(1024).IsUnicode(false);
            Property(p => p.IsInit).HasColumnOrder(230);
            Property(p => p.CreatedOn).HasColumnOrder(250);
            Property(p => p.ModifiedOn).HasColumnOrder(270);

            //HasRequired(f => f.Application).WithMany(a => a.Files).HasForeignKey(f => f.ApplicationId).WillCascadeOnDelete();

            MapToStoredProcedures(s=>s.Insert())
        }
        #endregion
    }
}