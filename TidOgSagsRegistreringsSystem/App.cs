using System;
using System.Data.Entity;
using System.Windows;
using DTO.Context;

namespace WPFApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Sæt database initializer
            Database.SetInitializer(new DbInitializer());

            // Initialiser databasen
            using (var context = new DatabaseContext())
            {
                try
                {
                    context.Database.Initialize(force: true);
                    Console.WriteLine("Database initialized successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database initialization failed: " + ex.Message,
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }
    }
}
