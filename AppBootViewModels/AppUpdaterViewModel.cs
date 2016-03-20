using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AppBootModels;
using Microsoft.Win32;


namespace AppBootViewModels
{
    public class AppUpdaterViewModel: AppReadWriteViewModelBase
    {
        #region Fields
        private ICommand _addFilesCommand;
        private ApplicationInfo _application;
        private bool _canAddFiles;
        private ICollection<FileInfo> _files;
        #endregion


        #region  Properties & Indexers
        private int _applicationId;

        public int ApplicationId
        {
            get { return _applicationId; }
            set { SetProperty(ref _applicationId, value); }
        }

        
        public ICommand AddFilesCommand => GetCommand(ref _addFilesCommand, _ => AddFiles(), _ => CanAddFiles);

        public ApplicationInfo Application
        {
            get { return _application; }
            private set { SetProperty(ref _application, value); }
        }

        public bool CanAddFiles
        {
            get { return _canAddFiles; }
            private set { SetProperty(ref _canAddFiles, value); }
        }

        public ICollection<FileInfo> Files
        {
            get { return _files; }
            private set { SetProperty(ref _files, value); }
        }
        #endregion


        #region Methods
        public void AddFiles()
        {
            var openDialog = new OpenFileDialog
            {
                Multiselect = true,
                ShowReadOnly = true,
            };
            if (openDialog.ShowDialog() == true)
            {
                AddFiles(openDialog.FileNames);
            }
        }
        #endregion


        #region Override
        protected override async Task LoadAsync()
        {
            SetEnability(false);
            Application = await _context.Applications.FindAsync(ApplicationId);
            await Task.Run(() => Files = new ObservableCollection<FileInfo>(Application.Files.ToList()));
            SetEnability(true);
        }

        protected override async Task SaveAsync()
        {
            SetEnability(false);
            //Application.SetFiles(Files);
            await _context.SaveChangesAsync();
            SetEnability(true);
        }

        protected override void SetEnability(bool value)
        {
            base.SetEnability(value);
            CanAddFiles = value;
        }
        #endregion


        #region Implementation
        private void AddFiles(IEnumerable<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                Application.Files.Add(new FileInfo(fileName, Application.Directory));
                Files = new ObservableCollection<FileInfo>(Application.Files.ToList());
            }
        }
        #endregion
    }
}