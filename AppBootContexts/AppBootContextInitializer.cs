using System.Data.Entity;


namespace AppBootContexts
{
    public class AppBootContextInitializer: DropCreateDatabaseIfModelChanges<AppBootContext>
    {
        #region Override
        protected override void Seed(AppBootContext context)
        {
            base.Seed(context);
        }
        #endregion
    }
}