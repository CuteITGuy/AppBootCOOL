using System;
using System.ComponentModel;


namespace AppBootModels
{
    [TypeConverter(typeof(FileVersionConverter))]
    public class FileVersion
    {
        #region  Constructors & Destructor
        public FileVersion(int build, int major, int minor, int revision)
        {
            Build = build;
            Major = major;
            Minor = minor;
            Revision = revision;
        }

        public FileVersion(Version version)
        {
            Version = version;
        }

        public FileVersion(string version)
        {
            if (!string.IsNullOrEmpty(version)) Version = new Version(version);
        }

        public FileVersion() { }
        #endregion


        #region  Properties & Indexers
        public int? Build { get; set; }
        public int? Major { get; set; }
        public int? Minor { get; set; }
        public int? Revision { get; set; }

        public Version Version
        {
            get
            {
                return Major.HasValue && Minor.HasValue && Build.HasValue && Revision.HasValue ?
                           new Version(Major.Value, Minor.Value, Build.Value, Revision.Value) :
                           Major.HasValue && Minor.HasValue && Build.HasValue ?
                               new Version(Major.Value, Minor.Value, Build.Value) :
                               Major.HasValue && Minor.HasValue ? new Version(Major.Value, Minor.Value) :
                                   null;
            }
            set
            {
                Major = value.Major;
                Minor = value.Minor;
                Build = value.Build;
                Revision = value.Revision;
            }
        }
        #endregion


        #region Override
        public override string ToString()
        {
            return Version?.ToString() ?? "";
        }
        #endregion
    }
}