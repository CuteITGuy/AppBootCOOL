using System.IO;
using System.Security.Cryptography;
using CB.Model.Common;


namespace AppBootModels
{
    public class FileData: ObservableObject
    {
        #region Fields
        private byte[] _data;
        private byte[] _hash;
        private int? _fileInfoId;
        private int _size;
        #endregion


        #region  Constructors & Destructor
        public FileData() { }

        public FileData(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("File not found", filePath);
            SetDataFrom(filePath);
        }
        #endregion


        #region  Properties & Indexers
        private FileInfo _fileInfo;

        public FileInfo FileInfo
        {
            get { return _fileInfo; }
            set { SetProperty(ref _fileInfo, value); }
        }

        
        public byte[] Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public byte[] Hash
        {
            get { return _hash; }
            set { SetProperty(ref _hash, value); }
        }

        public int? FileInfoId
        {
            get { return _fileInfoId; }
            set { SetProperty(ref _fileInfoId, value); }
        }

        public int Size
        {
            get { return _size; }
            set { SetProperty(ref _size, value); }
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

        private void SetDataFrom(string filePath)
        {
            Data = File.ReadAllBytes(filePath);
            Hash = ComputeHash(Data);
            Size = Data.Length;
        }
        #endregion
    }
}