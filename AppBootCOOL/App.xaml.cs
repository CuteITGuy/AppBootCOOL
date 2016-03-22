using System.Configuration;
using System.Linq;
using System.Windows;
using AppBootContexts;
using AppBootModels;


namespace AppBootCOOL
{
    public partial class App
    {
        #region Override
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using (var context = new AppBootContext())
            {
                var appId = GetAppId();
                var app = await context.Applications.FindAsync(appId);
                var fileIds = app.Files.Where(IsUpdated).Select(f => f.Id);
            }
        }
        #endregion


        #region Implementation
        private int GetAppId()
        {
            return int.Parse(ConfigurationManager.AppSettings["appId"]);
        }

        private static bool IsUpdated(FileInfo file)
        {
            var currentFile = file.Directory + file.Name;
            return !file.Version.HasVersion || file.Version.CompareTo(FileInfo.GetFileVersion(currentFile)) > 0;
        }
        #endregion
    }
}