using System.Data.Entity;
using System.Windows;
using DAL.Context;

namespace WPFApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // sdætter en database-initializer til at oprette databasen automatisk
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseContext>());

            // initialiser databasen
            using (var context = new DatabaseContext())
            {
                context.Database.Initialize(force: true);
            }
        }
    }
}
