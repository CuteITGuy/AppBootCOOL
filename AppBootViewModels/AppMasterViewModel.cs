using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AppBootModels;


namespace AppBootViewModels
{
    public class AppMasterViewModel: AppReadWriteViewModelBase
    {
        #region Fields
        private ICollection<ApplicationInfo> _applications;
        #endregion


        #region  Properties & Indexers
        public ICollection<ApplicationInfo> Applications
        {
            get { return _applications; }
            private set { SetProperty(ref _applications, value); }
        }
        #endregion


        #region Override
        protected override async Task LoadAsync()
        {
            SetEnability(false);
            await _context.Applications.ToListAsync();
            Applications = _context.Applications.Local;
            SetEnability(true);
        }

        protected override async Task SaveAsync()
        {
            SetEnability(false);
            await _context.SaveChangesAsync();
            await _context.Applications.ToListAsync();
            SetEnability(true);
        }
        #endregion
    }
}