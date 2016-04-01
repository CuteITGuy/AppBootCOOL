using System.Threading.Tasks;
using AppBootModels;


namespace AppBootContexts
{
    public interface IAppFileDataAccess
    {
        #region Abstract
        void DeleteFile(FileInfo file);
        Task DeleteFileAsync(FileInfo file);
        FileInfo[] GetFiles(int appId);
        Task<FileInfo[]> GetFilesAsync(int appId);
        FileInfo SaveFile(FileInfo file);
        Task<FileInfo> SaveFileAsync(FileInfo file);
        #endregion
    }
}