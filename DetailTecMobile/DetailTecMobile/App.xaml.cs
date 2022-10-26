using DetailTecMobile.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTecMobile
{
    public partial class App : Application
    {

        private static SQLDBHelper database;

        // Create the database connection as a singleton.
        public static SQLDBHelper Database
        {
            get
            {
                if (database == null)
                {
                    try
                    {
                        database = new SQLDBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DetailTECMobile.db3"));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Failed to load database.");
                    }

                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new GreetPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
