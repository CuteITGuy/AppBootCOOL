using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using CB.Model.Common;


namespace AppBootModels
{
    public class FileInfo: ObservableObject
    {
        #region Fields
        private ApplicationInfo _application;
        private int _applicationId;
        private DateTime? _createdOn;
        private byte[] _data;
        private string _description;
        private string _directory;
        private string _extension;
        private byte[] _hash;
        private int? _id;
        private bool _isInit;
        private DateTime? _modifiedOn;
        private string _name;
        private int _size;
        private string _version;
        #endregion


        #region  Constructors & Destructor
        public FileInfo() { }

        public FileInfo(string filePath, string appFolder)
        {
            if (!File.Exists(filePath)) throw new IOException(nameof(filePath));
            SetDataFrom(filePath, appFolder);
        }
        #endregion


        #region  Properties & Indexers
        public ApplicationInfo Application
        {
            get { return _application; }
            set { SetProperty(ref _application, value); }
        }

        public int ApplicationId
        {
            get { return _applicationId; }
            set { SetProperty(ref _applicationId, value); }
        }

        public DateTime? CreatedOn
        {
            get { return _createdOn; }
            set { SetProperty(ref _createdOn, value); }
        }

        public byte[] Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public string Directory
        {
            get { return _directory; }
            set { SetProperty(ref _directory, value); }
        }

        public string Extension
        {
            get { return _extension; }
            set { SetProperty(ref _extension, value); }
        }

        public byte[] Hash
        {
            get { return _hash; }
            set { SetProperty(ref _hash, value); }
        }

        public int? Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public bool IsInit
        {
            get { return _isInit; }
            set { SetProperty(ref _isInit, value); }
        }

        public DateTime? ModifiedOn
        {
            get { return _modifiedOn; }
            set { SetProperty(ref _modifiedOn, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public int Size
        {
            get { return _size; }
            set { SetProperty(ref _size, value); }
        }

        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }
        #endregion


        #region Implementation
        private static byte[] ComputeHash(byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(data);
            }
        }

        private static string GetVersion(string filePath)
        {
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            return fileVersionInfo.FileVersion;
        }

        private void SetDataFrom(string filePath, string appFolder)
        {
            Name = Path.GetFileName(filePath);
            Extension = Path.GetExtension(filePath);
            Directory = Path.GetDirectoryName(filePath); //UNDONE
            Data = File.ReadAllBytes(filePath);
            Hash = ComputeHash(Data);
            Size = (int)new System.IO.FileInfo(filePath).Length;
            Version = GetVersion(filePath);
        }
        #endregion
    }
}