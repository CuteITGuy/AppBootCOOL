using System;
using AppBootContexts;
using CB.Model.Common;


namespace AppBootViewModels
{
    public abstract class AppBootViewModelBase: ViewModelBase, IDisposable
    {
        #region Fields
        protected readonly AppBootContext _context = new AppBootContext();
        #endregion


        #region Methods
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}