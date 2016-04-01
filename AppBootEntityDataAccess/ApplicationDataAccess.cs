using System;
using System.Threading.Tasks;
using AppBootContexts;
using AppBootModels;


namespace AppBootEntityDataAccess
{
    public class ApplicationDataAccess: IApplicationDataAccess
    {
        public void DeleteApplication(ApplicationInfo application)
        {
            throw new NotImplementedException();
        }

        public Task DeleteApplicationAsync(ApplicationInfo application)
        {
            throw new NotImplementedException();
        }

        public ApplicationInfo GetApplication(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationInfo> GetApplicationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationInfo[] GetApplications()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationInfo[]> GetApplicationsAsync()
        {
            throw new NotImplementedException();
        }

        public ApplicationInfo SaveApplication(ApplicationInfo application)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationInfo> SaveApplicationAsync(ApplicationInfo application)
        {
            throw new NotImplementedException();
        }
    }
}