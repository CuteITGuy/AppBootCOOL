using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppBootModels;
using FileInfo = AppBootModels.FileInfo;


namespace AppBootViewModels
{
    public class AppBootViewModel: AppBootViewModelBase
    {
        #region Fields
        private const string CHECKING = "Check for updates...";
        private const string UPDATING = "Updating...";
        private ICollection<FileUpdate> _fileUpdates = new ObservableCollection<FileUpdate>();
        #endregion


        #region  Properties & Indexers
        public ICollection<FileUpdate> FileUpdates
        {
            get { return _fileUpdates; }
            private set { SetProperty(ref _fileUpdates, value); }
        }
        #endregion


        #region Methods
        public async Task Boot()
        {
            State = CHECKING;
            try
            {
                var appId = GetAppId();
                var app = await _context.Applications.FindAsync(appId);
                foreach (var fileInfo in app.Files.AsEnumerable().Where(IsUpdated))
                {
                    FileUpdates.Add(new FileUpdate { Info = fileInfo, State = UpdateState.Pending });
                }

                State = UPDATING;
                var count = 0;
                FileUpdates.AsParallel().ForAll(f =>
                {
                    
                });
            }
            catch (Exception exception)
            {
                State = exception.Message;
            }
        }
        #endregion


        #region Implementation
        private static int GetAppId()
        {
            return int.Parse(ConfigurationManager.AppSettings["appId"]);
        }

        private static bool IsUpdated(FileInfo file)
        {
            var currentFile = file.Directory + file.Name;
            return !File.Exists(currentFile) || !file.Version.HasVersion ||
                   file.Version.CompareTo(FileInfo.GetFileVersion(currentFile)) > 0;
        }
        #endregion
    }
}